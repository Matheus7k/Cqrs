using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CqrsCurso.Domain.Contracts;
using CqrsCurso.Domain.Core;
using CqrsCurso.Domain.Domain;

namespace CqrsCurso.Domain.Commands.CreatePerson 
{
    public class CreatePersonCommandHandler : BaseHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async  Task<Guid> HandleAsync(CreatePersonCommand command, CancellationToken cancellation)
        {
            AddNotification("Shalom");
            SetStatusCode(HttpStatusCode.Accepted);

            var entity = _mapper.Map<Person>(command);

            await _personRepository.InsertAsync(entity, cancellationToken: cancellation);

            return entity.Id;
        }
    }
}
