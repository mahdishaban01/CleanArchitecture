using HR_Management.Application.DTOs.LeaveType.Validators;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class CreateLeaveTypeRequestHandler :
        IRequestHandler<CreateLeaveTypeRequest, long>
    {
        #region Constructor

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<long> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDTO);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveType = _mapper.Map<Domain.Entities.LeaveType>(request.CreateLeaveTypeDTO);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
