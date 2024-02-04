namespace HR_Management.Application.DTOs.LeaveType.Validators;

public class UpdateLeaveTypeDTOValidator : AbstractValidator<UpdateLeaveTypeDTO>
{
    public UpdateLeaveTypeDTOValidator()
    {
        Include(new ILeaveTypeDTOValidator());

        RuleFor(p => p.Id).NotNull()
            .WithMessage("{PropertyName} is required.");
    }
}
