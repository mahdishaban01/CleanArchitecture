using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveType.Handlers.Commands;
using HR_Management.Application.Features.LeaveType.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.Responses;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        CreateLeaveTypeDTO _leaveTypeDTO;
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
}
