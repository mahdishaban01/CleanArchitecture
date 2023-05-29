namespace HR_Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
        }
    }
}
