namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class CreateLeaveTypeRequestHandler :
        IRequestHandler<CreateLeaveTypeRequest, long>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<long> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<Domain.Entities.LeaveType>(request.LeaveTypeDTO);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
