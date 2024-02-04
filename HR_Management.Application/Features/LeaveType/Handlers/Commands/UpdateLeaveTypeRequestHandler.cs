using ValidationException = HR_Management.Application.Exceptions.ValidationException;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands;

public class UpdateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
    IRequestHandler<UpdateLeaveTypeRequest, Unit>
{
    public async Task<Unit> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        #region Validation

        var validator = new UpdateLeaveTypeDTOValidator();
        var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDTO, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        #endregion

        var leaveType = await leaveTypeRepository.Get(request.UpdateLeaveTypeDTO.Id);
        mapper.Map(request.UpdateLeaveTypeDTO, leaveType);
        await leaveTypeRepository.Update(leaveType);

        return Unit.Value;
    }
}
