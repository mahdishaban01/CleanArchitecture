﻿using HR_Management.Domain.Entities;

namespace HR_Management.Application.UnitTests.Mocks;

public static class MockLeaveRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>()
        {
            new() {
            Id = 1,
            DefaultDay = 10,
            Name = "Test Vacation"
            },
            new() {
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
