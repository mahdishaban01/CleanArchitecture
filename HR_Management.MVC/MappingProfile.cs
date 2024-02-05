namespace HR_Management.MVC;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLeaveTypeDTO, CreateLeaveTypeVM>().ReverseMap();
        CreateMap<UpdateLeaveTypeDTO, UpdateLeaveTypeVM>().ReverseMap();
        CreateMap<LeaveTypeDTO, LeaveTypeVM>().ReverseMap();
    }
}
