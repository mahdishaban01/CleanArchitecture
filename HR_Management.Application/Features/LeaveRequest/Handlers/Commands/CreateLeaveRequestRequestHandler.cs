namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestRequestHandler :
        IRequestHandler<CreateLeaveRequestRequest, long>
    {
        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public CreateLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<long> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var leaveReuqest = _mapper.Map<Domain.Entities.LeaveRequest>(request.LeaveRequestDTO);
            leaveReuqest = await _leaveRequestRepository.Add(leaveReuqest);
            return leaveReuqest.Id;
        }
    }
}
