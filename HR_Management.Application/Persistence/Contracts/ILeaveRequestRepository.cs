namespace HR_Management.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(long id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
    }
}
