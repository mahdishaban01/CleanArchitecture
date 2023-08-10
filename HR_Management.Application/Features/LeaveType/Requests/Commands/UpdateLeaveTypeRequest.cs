namespace HR_Management.Application.Features.LeaveType.Requests.Commands
{
    public class UpdateLeaveTypeRequest : IRequest<Unit>
    {
        public UpdateLeaveTypeDTO UpdateLeaveTypeDTO { get; set; }
    }
}
