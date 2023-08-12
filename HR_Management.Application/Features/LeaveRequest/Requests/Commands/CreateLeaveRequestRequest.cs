using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class CreateLeaveRequestRequest : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}
