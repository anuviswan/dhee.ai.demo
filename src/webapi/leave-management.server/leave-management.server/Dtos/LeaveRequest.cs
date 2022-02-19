using System;

namespace leave_management.server.Dtos
{
    public enum LeaveType
    {
        Casual,
        Sick
    }
    public class LeaveRequest
    {
        public LeaveType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
