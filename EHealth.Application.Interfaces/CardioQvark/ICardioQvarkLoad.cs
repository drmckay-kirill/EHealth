using EHealth.Application.Interfaces.Base;
using EHealth.Data.CardioQvark.Interfaces.Entities;
using System.Threading.Tasks;

namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Сервис сохранения данных, полученных из API CardioQVARK
    /// </summary>
    public interface ICardioQvarkLoad : ILoadService
    {
        Task Load(Cardiogram entity);
    }
}
