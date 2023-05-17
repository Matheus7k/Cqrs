using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CqrsCurso.Repository.Repositories
{
    public abstract class BaseRepository<TEntity>
    {
        protected BaseRepository(IMongoClient client, IOptions<MongoRepositorySetting> setting)
        {
            var database = client.GetDatabase(setting.Value.DatabaseName);
            Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        protected readonly IMongoCollection<TEntity> Collection;
    }
}
