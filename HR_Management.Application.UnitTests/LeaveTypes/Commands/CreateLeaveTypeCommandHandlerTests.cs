using HR_Management.Application.Features.LeaveType.Handlers.Commands;
using HR_Management.Application.Features.LeaveType.Requests.Commands;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    readonly IMapper _mapper;
    readonly Mock<ILeaveTypeRepository> _mockRepository;
    readonly CreateLeaveTypeDTO _leaveTypeDTO;
    public CreateLeaveTypeCommandHandlerTests()
    {
        _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        _leaveTypeDTO = new CreateLeaveTypeDTO()
        {
            DefaultDay = 15,
            Name = "Test DTO"
        };
    }

    [Fact]
    public async Task CreateLeaveType()
    {
        var handler = new CreateLeaveTypeRequestHandler(_mockRepository.Object, _mapper);
        var result = await handler.Handle(new CreateLeaveTypeRequest()
        {
            CreateLeaveTypeDTO = _leaveTypeDTO
        }, CancellationToken.None);

        result.ShouldBeOfType<BaseCommandResponse>();

        var leaveTypes = await _mockRepository.Object.GetAll();

        leaveTypes.Count.ShouldBe(3);
    }

 
}
