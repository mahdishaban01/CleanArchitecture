using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain.Entities;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository:GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext)
            :base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
