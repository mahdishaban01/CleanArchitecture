namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands;

public class DeleteLeaveAllocationRequest : IRequest
{
    public long Id { get; set; }
}
