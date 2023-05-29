namespace HR_Management.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler :
        IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDTO>
    {
        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository
                .GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }
    }
}
