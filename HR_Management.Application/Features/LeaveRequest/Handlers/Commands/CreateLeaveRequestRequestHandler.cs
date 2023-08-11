using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestRequestHandler :
        IRequestHandler<CreateLeaveRequestRequest, long>
    {
        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<long> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            #endregion

            var leaveReuqest = _mapper.Map<Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDTO);
            leaveReuqest = await _leaveRequestRepository.Add(leaveReuqest);
            return leaveReuqest.Id;
        }
    }
}
