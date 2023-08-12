using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationRequestHandler :
        IRequestHandler<CreateLeaveAllocationRequest, BaseCommandResponse>
    {
        #region Constructor

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveAllocation = _mapper.Map<Domain.Entities.LeaveAllocation>(request.CreateLeaveAllocationDTO);
                leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

                response.Success = true;
                response.Message = "Creation Succesdsful";
                response.Id = leaveAllocation.Id;
            }

            return response;
        }
    }
}
