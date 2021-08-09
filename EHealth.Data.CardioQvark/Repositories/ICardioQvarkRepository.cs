using EHealth.Data.CardioQvark.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHealth.Data.CardioQvark.Interfaces.Repositories
{
    public interface ICardioQvarkRepository
    {
        Task Save(ICollection<Cardiogram> data);
    }
}
