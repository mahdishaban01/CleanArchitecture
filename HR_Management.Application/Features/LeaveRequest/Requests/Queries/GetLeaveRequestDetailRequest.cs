namespace HR_Management.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDTO>
    {
        public long Id { get; set; }
    }
}
