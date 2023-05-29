namespace HR_Management.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDTO>
    {
        public long Id { get; set; }
    }
}
