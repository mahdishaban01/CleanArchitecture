namespace HR_Management.Application.Features.LeaveType.Handlers.Commands;

public class CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
    IRequestHandler<CreateLeaveTypeRequest, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveTypeDTOValidator();
        var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDTO, cancellationToken);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var leaveType = mapper.Map<Domain.Entities.LeaveType>(request.CreateLeaveTypeDTO);
            leaveType = await leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Creation Succesdsful";
            response.Id = leaveType.Id;
        }
        return response;
    }
}
