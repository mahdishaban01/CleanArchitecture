namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationDetailRequestHandler :
        IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDTO>
    {
        #region Constructor

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository
                .GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}
