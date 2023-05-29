namespace HR_Management.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler :
        IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDTO>>
    {
        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)    
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestsList = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            return _mapper.Map<List<LeaveRequestDTO>>(leaveRequestsList);
        }
    }
}
