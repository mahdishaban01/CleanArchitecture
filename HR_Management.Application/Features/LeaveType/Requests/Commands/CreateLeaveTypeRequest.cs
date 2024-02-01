namespace HR_Management.Application.Features.LeaveType.Requests.Commands
{
    public class CreateLeaveTypeRequest : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDTO CreateLeaveTypeDTO { get; set; }
    }
}
