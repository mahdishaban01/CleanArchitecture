using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveRequestRepository(LeaveManagementDbContext dbContext) : 
        GenericRepository<LeaveRequest>(dbContext), ILeaveRequestRepository
    {
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool approvalStatus)
        {
            leaveRequest.IsApprove = approvalStatus;
            dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await dbContext.LeaveRequests
                .Include(t=>t.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(long id)
        {
            var leaveRequest = await dbContext.LeaveRequests
                 .Include(t => t.LeaveType)
                 .SingleOrDefaultAsync(l=>l.Id == id);
            return leaveRequest;
        }
    }
}
