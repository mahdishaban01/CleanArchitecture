namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands;

public class CreateLeaveAllocationRequest : IRequest<BaseCommandResponse>
{
    public CreateLeaveAllocationDTO CreateLeaveAllocationDTO { get; set; }
}
