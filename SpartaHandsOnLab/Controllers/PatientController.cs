using Lab.Application.Helpers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(IEnumerable<PatientDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var query = new PatientListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
