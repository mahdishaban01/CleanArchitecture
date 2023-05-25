using HR_Management.Application.Features.LeaveType.Requests.Queries;

namespace HR_Management.Application.Features.LeaveType.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandler :
        IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDTO>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}
