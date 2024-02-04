namespace HR_Management.Application.Features.LeaveType.Requests.Commands;

public class DeleteLeaveTypeRequest : IRequest
{
    public long Id { get; set; }
}
