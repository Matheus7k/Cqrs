using AutoMapper;
using CqrsCurso.Domain.Contracts;
using CqrsCurso.Domain.Core;
using CqrsCurso.Domain.Domain;

namespace CqrsCurso.Domain.Queries.ListPerson
{
    public class ListPersonQueryHandler : BaseHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ListPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<ListPersonQueryResponse>> HandleAsync(ListPersonQuery query, CancellationToken cancellationToken)
        {
            var people = await _personRepository.GetAsync(person => (query.Name == null || person.Name.Contains(query.Name.ToUpper())) 
            && (query.CPF == null || person.CPF.Contains(query.CPF)), cancellationToken);

            return _mapper.Map<List<ListPersonQueryResponse>>(people);
        }
    }
}
