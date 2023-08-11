using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class DeleteLeaveAllocationRequestHandler :
        IRequestHandler<DeleteLeaveAllocationRequest>
    {
        #region Constructor

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task Handle(DeleteLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation == null)
                throw new NotFoundException(nameof(Domain.Entities.LeaveAllocation), request.Id);

            await _leaveAllocationRepository.Delete(leaveAllocation);
        }
    }
}
