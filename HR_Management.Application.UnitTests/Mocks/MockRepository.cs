using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain.Entities;
using Moq;

namespace HR_Management.Application.UnitTests.Mocks
{
    public static class MockLeaveRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType
                {
                Id = 1,
                DefaultDay = 10,
                Name = "Test Vacation"
                },
                new LeaveType
                {
                Id = 2,
                DefaultDay = 15,
                Name = "Test Sick"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leavetype) =>
                {
                    leaveTypes.Add(leavetype);
                    return leavetype;
                });

            return mockRepo;
        }
    }
}
