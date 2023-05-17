using CqrsCurso.Domain.Commands.CreatePerson;
using CqrsCurso.Domain.Core;
using CqrsCurso.Domain.Domain;
using CqrsCurso.Domain.Queries.GetPerson;
using CqrsCurso.Domain.Queries.ListPerson;
using Microsoft.AspNetCore.Mvc;

namespace CqrsCurso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly CreatePersonCommandHandler _createPersonCommandHandler;
        private readonly ListPersonQueryHandler _listPersonQueryHandler;
        private readonly GetPersonQueryHandler _getPersonQueryHandler;

        public PeopleController(CreatePersonCommandHandler createPersonCommandHandler, ListPersonQueryHandler listPersonQueryHandler, GetPersonQueryHandler getPersonQueryHandler)
        {
            _createPersonCommandHandler = createPersonCommandHandler;
            _listPersonQueryHandler = listPersonQueryHandler;
            _getPersonQueryHandler = getPersonQueryHandler;
        }

        [HttpPost(Name = "InsertPerson")]
        public async Task<IActionResult> InsertPeopleAsync(CreatePersonCommand createPersonCommand, CancellationToken cancellationToken)
        {
            var result = await _createPersonCommandHandler.HandleAsync(createPersonCommand, cancellationToken);

            return GetResponse(_createPersonCommandHandler, result);
        }

        [HttpGet(Name = "GetPeople")]
        public async Task<IActionResult> GetPeopleAsync([FromQuery] string? name, [FromQuery] string? cpf, CancellationToken cancellationToken)
        {
            var result = await _listPersonQueryHandler.HandleAsync(new ListPersonQuery(name, cpf), cancellationToken);

            return GetResponse(_createPersonCommandHandler, result);
        }

        [HttpGet("{Id:Guid}", Name = "GetPersonById")]
        public async Task<IActionResult> GetPersonById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _getPersonQueryHandler.HandleAsync(new GetPersonQuery(id), cancellationToken);

            return GetResponse(_getPersonQueryHandler, result);
        }

        private IActionResult GetResponse<THandler, TResponse>(THandler handler, TResponse response)
            where THandler : BaseHandler
        {
            return StatusCode((int)handler.GetStatusCode(), new { Data = response, Notifications = handler.GetNotifications() });
        }

        private IActionResult GetResponse<THandler>(THandler handler)
            where THandler : BaseHandler
        {
            return StatusCode((int)handler.GetStatusCode(), new { Notifications = handler.GetNotifications() });
        }
    }
}
