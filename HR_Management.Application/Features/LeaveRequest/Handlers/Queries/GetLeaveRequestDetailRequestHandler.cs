namespace HR_Management.Application.Features.LeaveRequest.Handlers.Queries;

public class GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper) :
    IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDTO>
{
    public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await leaveRequestRepository
            .GetLeaveRequestWithDetails(request.Id);
        return mapper.Map<LeaveRequestDTO>(leaveRequest);
    }
}
