namespace HR_Management.Domain.Entities
{
    public class LeaveType : BaseEntity
    {
        #region Properties

        public string Name { get; set; }
        public int DefaultDay { get; set; }

        #endregion
    }
}
