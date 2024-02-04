namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper) :
    IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
{
    public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocationList = await leaveAllocationRepository
            .GetLeaveAllocationsWithDetails();
        return mapper.Map<List<LeaveAllocationDTO>>(leaveAllocationList);
    }
}
