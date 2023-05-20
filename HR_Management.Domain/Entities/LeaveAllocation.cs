namespace HR_Management.Domain.Entities
{
    public class LeaveAllocation : BaseEntity
    {
        #region Properties

        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }

        #endregion

        #region Relations

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        #endregion
    }
}
