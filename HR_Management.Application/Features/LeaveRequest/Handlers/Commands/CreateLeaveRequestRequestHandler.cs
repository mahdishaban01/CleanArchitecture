using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Models;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository,
        IEmailSender emailSender, IMapper mapper) :
        IRequestHandler<CreateLeaveRequestRequest, BaseCommandResponse>
    {
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveReuqest = mapper.Map<Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDTO);
                leaveReuqest = await leaveRequestRepository.Add(leaveReuqest);

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
                    await emailSender.SendEmail(email);
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
