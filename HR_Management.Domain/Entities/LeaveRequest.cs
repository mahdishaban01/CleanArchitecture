namespace HR_Management.Domain.Entities;

public class LeaveRequest : BaseEntity
{
    #region Properties

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public string RequestComments { get; set; }
    public DateTime? ActionDate { get; set; }
    public bool IsApprove { get; set; }
    public bool IsCancel { get; set; }

    #endregion

    #region Relations

    [ForeignKey("LeaveTypeId")]
    public LeaveType LeaveType { get; set; }

    #endregion
}
