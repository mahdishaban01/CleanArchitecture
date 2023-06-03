namespace HR_Management.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(long id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool IsApprove);
    }
}
