using EHealth.Application.Interfaces.CardioQvark;
using System.Threading.Tasks;

namespace EHealth.Application.Services.CardioQvark
{
    /// <summary>
    /// <inheritdoc cref="ICardioQvarkETL"/>
    /// </summary>
    public class CardioQvarkETL : ICardioQvarkETL
    {
        private readonly ICardioQvarkExtract _extractService;
        private readonly ICardioQvarkTransform _transformService;
        private readonly ICardioQvarkLoad _loadService;

        public CardioQvarkETL(ICardioQvarkExtract extractService, ICardioQvarkLoad loadService, ICardioQvarkTransform transformService)
        {
            _extractService = extractService;
            _loadService = loadService;
            _transformService = transformService;
        }

        public async Task Handle(QueryParameters queryParameters)
        {
            var extractResult = await _extractService.Extract(queryParameters);

            if (queryParameters.AccessPolicy is { Length: > 0 })
            {
                foreach (var res in extractResult)
                {
                    res.EncryptedValue = await _transformService.Transform(res.Value, queryParameters.AccessPolicy);
                }
            }
            
            await _loadService.Load(extractResult);
        }
    }
}
