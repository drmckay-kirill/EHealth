using EHealth.Application.Interfaces.CardioQvark;
using EHealth.Data.CardioQvark.Interfaces.Entities;
using EHealth.Data.CardioQvark.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHealth.Application.Services.CardioQvark
{
    public class CardioQvarkLoad : ICardioQvarkLoad
    {
        private readonly ICardioQvarkRepository _repository;

        public CardioQvarkLoad(ICardioQvarkRepository repository)
        {
            _repository = repository;
        }

        public async Task Load(ICollection<ExtractResult> cardioAnalysises)
        {
            var cardiograms = cardioAnalysises
                .Select(x => new Cardiogram
                {
                    DeviceNumber = x.DeviceSerial,
                    PatientId = x.AccountId.ToString(),
                    CardiogramId = x.CardiogramId,
                    Method = x.MethodId,
                    DataView = x.Value.ToString()
                })
                .ToList();

            await _repository.Save(cardiograms);
        }
    }
}
