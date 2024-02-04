namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands;

public class DeleteLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository) :
    IRequestHandler<DeleteLeaveAllocationRequest>
{
    public async Task Handle(DeleteLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await leaveAllocationRepository.Get(request.Id) 
            ?? throw new NotFoundException(nameof(Domain.Entities.LeaveAllocation), request.Id);
        await leaveAllocationRepository.Delete(leaveAllocation);
    }
}
