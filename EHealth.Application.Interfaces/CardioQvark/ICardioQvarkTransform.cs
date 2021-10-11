using EHealth.Application.Interfaces.Base;
using System.Threading.Tasks;

namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Сервис преобразования данных полученных из API CardioQVARK
    /// </summary>
    public interface ICardioQvarkTransform : ITransformService
    {
        Task<byte[]> Transform(object result, string[] accessPolicy);
    }
}
