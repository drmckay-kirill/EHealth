using EHealth.Application.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Сервис загрузки данных из API CardioQVARK
    /// </summary>
    public interface ICardioQvarkExtract : IExtractService
    {
        Task<ICollection<AnalysisResult>> Extract(QueryParameters queryParameters);
    }
}
