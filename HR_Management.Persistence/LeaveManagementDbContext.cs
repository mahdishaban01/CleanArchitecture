using HR_Management.Domain.Common;

namespace HR_Management.Persistence
{
    public class LeaveManagementDbContext : DbContext
    {
        #region Constructor

        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options) { }

        #endregion

        #region Entities

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        }

        #endregion

        #region SaveChangesAsync

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifyDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

        #region SaveChanges

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifyDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        #endregion
    }
}
