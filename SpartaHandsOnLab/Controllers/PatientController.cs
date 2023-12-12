using Lab.Application.Helpers.Commands.Delete;
using Lab.Application.Helpers.Commands.Update;
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

        [HttpGet("Get/{id}")]
        [ProducesResponseType(typeof(IEnumerable<PatientDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll(int id)
        {
            var query = new PatientListQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var command = new DeletePatientCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}", Name = "Update")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePatient(int id, [FromBody]UpdatePatientCommand command)
        {
            if (id == 0)
            {
                return BadRequest("Patient id mismatch");
            }
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
