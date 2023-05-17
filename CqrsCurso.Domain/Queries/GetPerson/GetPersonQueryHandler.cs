using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CqrsCurso.Domain.Contracts;
using CqrsCurso.Domain.Core;

namespace CqrsCurso.Domain.Queries.GetPerson
{
    public class GetPersonQueryHandler : BaseHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<GetPersonQuery> HandleAsync(GetPersonQuery command, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetByIdAsync(command.Id, cancellationToken);

            if (!string.IsNullOrWhiteSpace(result?.Name))
                return _mapper.Map<GetPersonQuery>(result);

            AddNotification($"Person with id = {command.Id} does not exist.");
            SetStatusCode(HttpStatusCode.NotFound);
            return null;
        }
    }
}
