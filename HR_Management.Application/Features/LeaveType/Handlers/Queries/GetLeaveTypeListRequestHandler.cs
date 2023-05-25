using HR_Management.Application.Features.LeaveType.Requests.Queries;

namespace HR_Management.Application.Features.LeaveType.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler :
        IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
        }
    }
}
