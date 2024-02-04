namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands;

public class DeleteLeaveRequestRequestHandler(ILeaveTypeRepository leaveTypeRepository) :
    IRequestHandler<DeleteLeaveRequestRequest>
{
    public async Task Handle(DeleteLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await leaveTypeRepository.Get(request.Id)
            ?? throw new NotFoundException(nameof(Domain.Entities.LeaveRequest), request.Id);
        await leaveTypeRepository.Delete(leaveRequest);
    }
}
