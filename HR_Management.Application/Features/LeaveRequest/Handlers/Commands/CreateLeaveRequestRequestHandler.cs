using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Models;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestRequestHandler :
        IRequestHandler<CreateLeaveRequestRequest, BaseCommandResponse>
    {
        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public CreateLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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
                response.Message = "Creation Successful";
                response.Id = leaveReuqest.Id;

                var email = new Email()
                {
                    To = "mahdishaban33@gmail.com",
                    Subject = "LeaveRequest Submitted",
                    Body = $"Your Leave Request For {request.CreateLeaveRequestDTO.StartDate} " +
                    $"To {request.CreateLeaveRequestDTO.EndDate} " +
                    $"Has Been Submitted"
                };

                try
                {
                    await _emailSender.SendEmail(email);
                }
                catch (Exception)
                {
                    //log
                }

            }
            return response;
        }
    }
}
