using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CqrsCurso.Domain.Domain;

namespace CqrsCurso.Domain.Contracts
{
    public interface IPersonRepository
    {
        Task InsertAsync(Person person, CancellationToken cancellationToken);
        Task<IEnumerable<Person>> GetAsync(Expression<Func<Person, bool>> expression, CancellationToken cancellationToken);
        Task<Person> GetByIdAsync(Guid personId, CancellationToken cancellationToken);
    }
}
