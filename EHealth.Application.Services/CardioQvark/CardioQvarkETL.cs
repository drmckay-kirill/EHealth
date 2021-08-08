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

        public CardioQvarkETL(ICardioQvarkExtract extractService)
        {
            _extractService = extractService;
        }

        public async Task Handle(QueryParameters queryParameters)
        {
            var analysis = await _extractService.Extract(queryParameters);

            var breakPoint = 5;
        }
    }
}
