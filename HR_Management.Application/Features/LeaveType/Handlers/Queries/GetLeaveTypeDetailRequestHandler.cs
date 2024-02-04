namespace HR_Management.Application.Features.LeaveType.Handlers.Queries;

public class GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
    IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDTO>
{
    public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.Get(request.Id);
        return mapper.Map<LeaveTypeDTO>(leaveType);
    }
}
