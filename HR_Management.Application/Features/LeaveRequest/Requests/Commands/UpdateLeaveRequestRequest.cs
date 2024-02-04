namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands;

public class UpdateLeaveRequestRequest : IRequest<Unit>
{
    public long Id { get; set; }

    public UpdateLeaveRequestDTO UpdateLeaveRequestDTO { get; set; }

    public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDTO { get; set; }
}
