namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands
{
    public class CreateLeaveAllocationRequest : IRequest<long>
    {
        public CreateLeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}
