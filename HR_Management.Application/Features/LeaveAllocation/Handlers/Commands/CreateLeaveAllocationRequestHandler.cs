namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationRequestHandler :
        IRequestHandler<CreateLeaveAllocationRequest, long>
    {
        #region Constructor

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public CreateLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<long> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<Domain.Entities.LeaveAllocation>(request.LeaveAllocationDTO);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
