using EHealth.Application.Interfaces.Base;
using System.Threading.Tasks;

namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Выполнить ETL процедуру данных из API CardioQVARK
    /// </summary>
    public interface ICardioQvarkETL : IETLService
    {
        Task Handle(QueryParameters queryParameters);
    }
}
