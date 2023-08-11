using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class UpdateLeaveTypeRequestHandler :
        IRequestHandler<UpdateLeaveTypeRequest, Unit>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<Unit> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            #endregion

            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDTO.Id);
            _mapper.Map(request.UpdateLeaveTypeDTO, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
