namespace HR_Management.Application.Features.LeaveType.Handlers.Commands;

public class DeleteLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository) :
    IRequestHandler<DeleteLeaveTypeRequest>
{
    public async Task Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.Get(request.Id) 
            ?? throw new NotFoundException(nameof(Domain.Entities.LeaveType), request.Id);
        await leaveTypeRepository.Delete(leaveType);
    }
}
