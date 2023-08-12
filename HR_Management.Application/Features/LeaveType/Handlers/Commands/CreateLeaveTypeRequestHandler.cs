using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Responses;
using HR_Management.Domain.Entities;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class CreateLeaveTypeRequestHandler :
        IRequestHandler<CreateLeaveTypeRequest, BaseCommandResponse>
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

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<Domain.Entities.LeaveType>(request.CreateLeaveTypeDTO);
                leaveType = await _leaveTypeRepository.Add(leaveType);

                response.Success = true;
                response.Message = "Creation Succesdsful";
                response.Id = leaveType.Id;
            }
            return response;
        }
    }
}
