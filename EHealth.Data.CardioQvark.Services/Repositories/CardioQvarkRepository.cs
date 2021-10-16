using EHealth.Data.CardioQvark.Interfaces.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHealth.Data.CardioQvark.Interfaces.Repositories
{
    public class CardioQvarkRepository : ICardioQvarkRepository
    {
        private readonly IMongoCollection<Cardiogram> _entities;

        public CardioQvarkRepository(IOptions<CardioQvarkDbOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var database = client.GetDatabase(options.Value.DatabaseName);
            _entities = database.GetCollection<Cardiogram>(options.Value.CollectionName);
        }

        public async Task Save(ICollection<Cardiogram> data)
        {
            foreach (var entity in data)
            {
                //var existingEntity = await _entities
                //    .Find(x => x.CardiogramId == entity.CardiogramId)
                //    .AnyAsync();

                //if (existingEntity)
                //    continue;

                await _entities.InsertOneAsync(entity);
            }
        }
    }
}
