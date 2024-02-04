using ValidationException = HR_Management.Application.Exceptions.ValidationException;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands;

public class UpdateLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
    IRequestHandler<UpdateLeaveAllocationRequest, Unit>
{
    public async Task<Unit> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        #region Validation

        var validator = new UpdateLeaveAllocationDTOValidator(leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDTO, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        #endregion

        var leaveAllocation = await leaveAllocationRepository.Get(request.UpdateLeaveAllocationDTO.Id);
        mapper.Map(request.UpdateLeaveAllocationDTO, leaveAllocation);
        await leaveAllocationRepository.Update(leaveAllocation);

        return Unit.Value;
    }
}
