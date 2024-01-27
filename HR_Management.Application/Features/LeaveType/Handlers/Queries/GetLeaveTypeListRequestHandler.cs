namespace HR_Management.Application.Features.LeaveType.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper) :
        IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList = await leaveTypeRepository.GetAll();
            return mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
        }
    }
}
