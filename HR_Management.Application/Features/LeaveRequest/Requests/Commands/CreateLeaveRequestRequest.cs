namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class CreateLeaveRequestRequest : IRequest<long>
    {
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}
