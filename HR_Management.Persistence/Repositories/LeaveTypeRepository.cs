using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain.Entities;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository(LeaveManagementDbContext dbContext) :
        GenericRepository<LeaveType>(dbContext), ILeaveTypeRepository
    {
    }
}
