namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class DeleteLeaveRequestRequest : IRequest
    {
        public long Id { get; set; }
    }
}
