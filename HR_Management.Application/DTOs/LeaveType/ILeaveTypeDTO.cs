using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveType
{
    public interface ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
