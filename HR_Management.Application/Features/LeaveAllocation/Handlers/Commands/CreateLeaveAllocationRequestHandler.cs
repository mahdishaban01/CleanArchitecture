using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationRequestHandler :
        IRequestHandler<CreateLeaveAllocationRequest, long>
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

        public async Task<long> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new CreateLeaveAllocationDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDTO);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveAllocation = _mapper.Map<Domain.Entities.LeaveAllocation>(request.CreateLeaveAllocationDTO);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
