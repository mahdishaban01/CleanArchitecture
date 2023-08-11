using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class DeleteLeaveTypeRequestHandler :
        IRequestHandler<DeleteLeaveTypeRequest>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType == null)
                throw new NotFoundException(nameof(Domain.Entities.LeaveType), request.Id);

            await _leaveTypeRepository.Delete(leaveType);
        }
    }
}
