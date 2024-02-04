namespace HR_Management.Application.DTOs.LeaveType;

public class LeaveTypeDTO : BaseDTO, ILeaveTypeDTO
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}
