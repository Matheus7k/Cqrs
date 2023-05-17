using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CqrsCurso.Domain.Contracts;
using CqrsCurso.Domain.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CqrsCurso.Repository.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IMongoClient client, IOptions<MongoRepositorySetting> settings) : base(client, settings)
        {
            
        }

        public async Task InsertAsync(Person person, CancellationToken cancellation)
        {            
            await Collection.InsertOneAsync(person, cancellationToken: cancellation);
        }

        public async Task<IEnumerable<Person>> GetAsync(Expression<Func<Person, bool>> expression, CancellationToken cancellationToken)
        {
            var filter = Builders<Person>.Filter.Where(expression);

            return await Collection.Find(filter).ToListAsync(cancellationToken);
        }

        public async Task<Person> GetByIdAsync(Guid personId, CancellationToken cancellationToken)
        {
            var filter = Builders<Person>.Filter.Eq(person => person.Id, personId);

            return await Collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
