﻿namespace HR_Management.Application.Features.LeaveType.Requests.Commands
{
    public class CreateLeaveTypeRequest:IRequest<long>
    {
        public CreateLeaveTypeDTO CreateLeaveTypeDTO { get; set; }
    }
}
