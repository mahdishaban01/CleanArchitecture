namespace HR_Management.Application.DTOs.LeaveType.Validators;

public class ILeaveTypeDTOValidator : AbstractValidator<ILeaveTypeDTO>
{
    public ILeaveTypeDTOValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");

        RuleFor(p => p.DefaultDay)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
            .LessThan(100);
    }
}
