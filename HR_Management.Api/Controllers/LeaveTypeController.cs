using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveType.Requests.Commands;
using HR_Management.Application.Features.LeaveType.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(long id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDTO leaveType)
        {
            var command = new CreateLeaveTypeRequest { CreateLeaveTypeDTO = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] UpdateLeaveTypeDTO leaveType)
        {
            var command = new UpdateLeaveTypeRequest { UpdateLeaveTypeDTO = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteLeaveTypeRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
