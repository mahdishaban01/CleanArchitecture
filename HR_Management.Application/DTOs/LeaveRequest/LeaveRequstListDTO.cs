namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequstListDTO : BaseDTO
    {
        public LeaveType LeaveType { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApprove { get; set; }

    }
}
