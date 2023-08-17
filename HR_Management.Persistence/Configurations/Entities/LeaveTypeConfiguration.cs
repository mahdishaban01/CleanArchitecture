using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDay = 10,
                    Name = "Vacation",
                },
                 new LeaveType
                 {
                     Id = 2,
                     DefaultDay = 12,
                     Name = "Sick",
                 }
                );
        }
    }
}
