using ValidationException = HR_Management.Application.Exceptions.ValidationException;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands;

public class UpdateLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
    IRequestHandler<UpdateLeaveRequestRequest, Unit>
{
    public async Task<Unit> Handle(UpdateLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        #region Validation

        var validator = new UpdateLeaveRequestDTOValidator(leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDTO, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        #endregion

        var leaveRequest = await leaveRequestRepository.Get(request.UpdateLeaveRequestDTO.Id);
        if (request.UpdateLeaveRequestDTO != null)
        {
            mapper.Map(request.UpdateLeaveRequestDTO, leaveRequest);
            await leaveRequestRepository.Update(leaveRequest);
        }
        else if (request.ChangeLeaveRequestApprovalDTO != null)
        {
            await leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDTO.IsApprove);
        }

        return Unit.Value;
    }
}
