using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository:GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations =await _dbContext.LeaveAllocations
                .Include(t=>t.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(long id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
               .Include(t => t.LeaveType)
               .SingleOrDefaultAsync(l=>l.Id==id);
            return leaveAllocation;
        }
    }
}
