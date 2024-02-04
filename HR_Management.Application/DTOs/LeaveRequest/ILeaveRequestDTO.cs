namespace HR_Management.Application.DTOs.LeaveRequest;

public interface ILeaveRequestDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
}
