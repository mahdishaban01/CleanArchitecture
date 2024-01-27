namespace HR_Management.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper) :
        IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDTO>>
    {
        public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestsList = await leaveRequestRepository.GetLeaveRequestsWithDetails();
            return mapper.Map<List<LeaveRequestDTO>>(leaveRequestsList);
        }
    }
}
