namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler :
        IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
    {
        #region Constructor

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocationList = await _leaveAllocationRepository
                .GetLeaveAllocationsWithDetails();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocationList);
        }
    }
}
