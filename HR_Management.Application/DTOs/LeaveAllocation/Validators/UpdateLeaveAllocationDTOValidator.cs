using FluentValidation;
using HR_Management.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDTOValidator : AbstractValidator<UpdateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));

            RuleFor(p => p.Id).NotNull()
                .WithMessage("{PropertyName} is required.");

        }
    }
}
