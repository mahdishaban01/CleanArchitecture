using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Features.LeaveRequest.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDTO>>> Get()
        {
            var leaveReques = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveReques);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var leaveReque = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
            return Ok(leaveReque);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDTO leaveRequest)
        {
            var command = new CreateLeaveRequestRequest { CreateLeaveRequestDTO = leaveRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDTO leaveRequest)
        {
            var command = new UpdateLeaveRequestRequest { Id = id, UpdateLeaveRequestDTO = leaveRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDTO changeLeaveRequestApproval)
        {
            var command = new UpdateLeaveRequestRequest { Id = id, ChangeLeaveRequestApprovalDTO = changeLeaveRequestApproval };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
