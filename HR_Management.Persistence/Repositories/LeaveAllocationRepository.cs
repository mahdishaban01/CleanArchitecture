using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository(LeaveManagementDbContext dbContext) : 
        GenericRepository<LeaveAllocation>(dbContext), ILeaveAllocationRepository
    {
        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations =await dbContext.LeaveAllocations
                .Include(t=>t.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(long id)
        {
            var leaveAllocation = await dbContext.LeaveAllocations
               .Include(t => t.LeaveType)
               .SingleOrDefaultAsync(l=>l.Id==id);
            return leaveAllocation;
        }
    }
}
