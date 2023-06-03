namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class DeleteLeaveRequestRequestHandler :
        IRequestHandler<DeleteLeaveRequestRequest>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveRequestRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task Handle(DeleteLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveTypeRepository.Get(request.Id);
            await _leaveTypeRepository.Delete(leaveRequest);
        }
    }
}
