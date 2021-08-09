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
        private readonly ICardioQvarkLoad _loadService;

        public CardioQvarkETL(ICardioQvarkExtract extractService, ICardioQvarkLoad loadService)
        {
            _extractService = extractService;
            _loadService = loadService;
        }

        public async Task Handle(QueryParameters queryParameters)
        {
            var extractResult = await _extractService.Extract(queryParameters);
            await _loadService.Load(extractResult);

            var breakPoint = 5;
        }
    }
}
