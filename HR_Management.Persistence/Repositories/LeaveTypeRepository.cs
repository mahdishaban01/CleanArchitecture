namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository(LeaveManagementDbContext dbContext) :
        GenericRepository<LeaveType>(dbContext), ILeaveTypeRepository
    {
    }
}
