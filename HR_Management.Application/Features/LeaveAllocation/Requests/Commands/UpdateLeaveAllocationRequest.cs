namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands
{
    public class UpdateLeaveAllocationRequest : IRequest<Unit>
    {
        public UpdateLeaveAllocationDTO UpdateLeaveAllocationDTO { get; set; }
    }
}
