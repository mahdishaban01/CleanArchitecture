namespace HR_Management.Application.Features.LeaveType.Requests.Queries;

public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDTO>
{
    public long Id { get; set; }
}
