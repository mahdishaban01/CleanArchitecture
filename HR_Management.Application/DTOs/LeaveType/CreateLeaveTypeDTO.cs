namespace HR_Management.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDTO :BaseDTO, ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
