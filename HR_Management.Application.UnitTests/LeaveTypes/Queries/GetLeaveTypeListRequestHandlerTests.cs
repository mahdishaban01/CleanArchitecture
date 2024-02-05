using HR_Management.Application.Features.LeaveType.Handlers.Queries;
using HR_Management.Application.Features.LeaveType.Requests.Queries;

namespace HR_Management.Application.UnitTests.LeaveTypes.Queries;

public class GetLeaveTypeListRequestHandlerTests
{
    readonly IMapper _mapper;
    readonly Mock<ILeaveTypeRepository> _mockRepository;
    public GetLeaveTypeListRequestHandlerTests()
    {
        _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypeListRequestHandler(_mockRepository.Object, _mapper);

        var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDTO>>();
        result.Count.ShouldBe(2);

    }
}
