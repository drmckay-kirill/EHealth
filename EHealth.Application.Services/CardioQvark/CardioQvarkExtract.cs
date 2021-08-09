using EHealth.Application.Interfaces.CardioQvark;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EHealth.Application.Services.CardioQvark
{
    /// <summary>
    /// <inheritdoc cref="ICardioQvarkExtract"/>
    /// </summary>
    public class CardioQvarkExtract : ICardioQvarkExtract
    {
        private readonly IOptions<CardioQvarkOptions> _options;
        private readonly IHttpClientFactory _clientFactory;

        public CardioQvarkExtract(
            IOptions<CardioQvarkOptions> options,
            IHttpClientFactory clientFactory
            )
        {
            _options = options;
            _clientFactory = clientFactory;
        }

        public async Task<ICollection<ExtractResult>> Extract(QueryParameters queryParameters)
        {
            if (string.IsNullOrEmpty(queryParameters.DeviceNumber)
                && string.IsNullOrEmpty(queryParameters.PatientId))
                throw new ArgumentException("Необходимо указать либо серийный номер устройства либо идентификатор пациента");

            var httpClient = _clientFactory.CreateClient(CardioQvarkConstants.HttpClientName);

            var cardioParams = new List<string>();

            if (!string.IsNullOrEmpty(queryParameters.DeviceNumber))
                cardioParams.Add($"deviceSerial={queryParameters.DeviceNumber}");

            if (!string.IsNullOrEmpty(queryParameters.PatientId))
                cardioParams.Add($"accountId={queryParameters.PatientId}");

            if (queryParameters.Offset.HasValue)
                cardioParams.Add($"minId={queryParameters.Offset}");

            var cardioUrl =
                $"{_options.Value.Endpoint}/cardiogram?{string.Join("&", cardioParams)}";

            var cardioResponse = await httpClient.GetStreamAsync(cardioUrl);
            var cardioRes =
                await JsonSerializer.DeserializeAsync<ICollection<CardiogramResult>>(cardioResponse);

            var res = new List<ExtractResult>();

            foreach (var cardio in cardioRes)
            {
                var analysisUrl =
                    $"{_options.Value.Endpoint}/analysis/{cardio.Id}/ecg-l1";
                var analysisRes = await httpClient.GetStreamAsync(analysisUrl);
                var analysis =
                    await JsonSerializer.DeserializeAsync<ICollection<AnalysisResult>>(analysisRes);

                res.AddRange(analysis.Select(x => new ExtractResult
                {
                    CardiogramId = x.CardiogramId,
                    Error = x.Error,
                    MethodId = x.MethodId,
                    Ts = x.Ts,
                    Value = x.Value
                }));
            }

            foreach (var cardioExtractRes in res)
            {
                var cardio = cardioRes.FirstOrDefault(x => x.Id == cardioExtractRes.CardiogramId);
                cardioExtractRes.AccountId = cardio.AccountId;
                cardioExtractRes.DeviceSerial = cardio.DeviceSerial;
            }

            return res;
        }
    }
}
