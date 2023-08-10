using FluentValidation;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class UpdateLeaveAllocationRequestHandler :
        IRequestHandler<UpdateLeaveAllocationRequest, Unit>
    {
        #region Constructor

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<Unit> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateLeaveAllocationDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDTO);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDTO.Id);
            _mapper.Map(request.UpdateLeaveAllocationDTO, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
