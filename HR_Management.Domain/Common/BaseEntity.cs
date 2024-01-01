namespace HR_Management.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
}
