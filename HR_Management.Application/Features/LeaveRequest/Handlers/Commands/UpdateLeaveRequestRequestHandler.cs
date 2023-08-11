using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestRequestHandler :
        IRequestHandler<UpdateLeaveRequestRequest, Unit>
    {
        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<Unit> Handle(UpdateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            #endregion

            var leaveRequest = await _leaveRequestRepository.Get(request.UpdateLeaveRequestDTO.Id);
            if (request.UpdateLeaveRequestDTO != null)
            {
                _mapper.Map(request.UpdateLeaveRequestDTO, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDTO != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDTO.IsApprove);
            }

            return Unit.Value;
        }
    }
}
