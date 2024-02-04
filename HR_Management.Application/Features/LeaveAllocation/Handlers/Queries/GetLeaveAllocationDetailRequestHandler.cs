namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper) :
    IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDTO>
{
    public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await leaveAllocationRepository
            .GetLeaveAllocationWithDetails(request.Id);
        return mapper.Map<LeaveAllocationDTO>(leaveAllocation);
    }
}
