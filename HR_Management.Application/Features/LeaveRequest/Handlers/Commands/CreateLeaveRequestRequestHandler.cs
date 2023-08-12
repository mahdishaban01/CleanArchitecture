using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestRequestHandler :
        IRequestHandler<CreateLeaveRequestRequest, BaseCommandResponse>
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

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveReuqest = _mapper.Map<Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDTO);
                leaveReuqest = await _leaveRequestRepository.Add(leaveReuqest);

                response.Success = true;
                response.Message = "Creation Succesdsful";
                response.Id = leaveReuqest.Id;
            }
            return response;
        }
    }
}
