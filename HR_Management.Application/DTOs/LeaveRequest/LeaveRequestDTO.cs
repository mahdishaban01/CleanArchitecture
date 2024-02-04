namespace HR_Management.Application.DTOs.LeaveRequest;

public class LeaveRequestDTO : BaseDTO, ILeaveRequestDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDTO LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public string RequestComments { get; set; }
    public DateTime? ActionDate { get; set; }
    public bool IsApprove { get; set; }
    public bool IsCancel { get; set; }
}
