namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
        IRequestHandler<CreateLeaveAllocationRequest, BaseCommandResponse>
    {
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDTOValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDTO, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveAllocation = mapper.Map<Domain.Entities.LeaveAllocation>(request.CreateLeaveAllocationDTO);
                leaveAllocation = await leaveAllocationRepository.Add(leaveAllocation);

                response.Success = true;
                response.Message = "Creation Succesdsful";
                response.Id = leaveAllocation.Id;
            }

            return response;
        }
    }
}
