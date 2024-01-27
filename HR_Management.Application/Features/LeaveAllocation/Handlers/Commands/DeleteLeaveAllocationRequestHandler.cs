using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class DeleteLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper) :
        IRequestHandler<DeleteLeaveAllocationRequest>
    {
        public async Task Handle(DeleteLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation == null)
                throw new NotFoundException(nameof(Domain.Entities.LeaveAllocation), request.Id);

            await leaveAllocationRepository.Delete(leaveAllocation);
        }
    }
}
