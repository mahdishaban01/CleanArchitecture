namespace HR_Management.Application.DTOs.LeaveRequest.Validators;

public class UpdateLeaveRequestDTOValidator : AbstractValidator<UpdateLeaveRequestDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveRequestDTOValidator(_leaveTypeRepository));
        RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("{PropertyName} is required.");
    }
}
