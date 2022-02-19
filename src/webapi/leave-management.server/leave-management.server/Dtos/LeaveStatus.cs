namespace leave_management.server.Dtos
{
    public class LeaveStatus
    {
        public int TotalCasualLeaves { get; set; }
        public int TotalSickLeaves { get; set; }

        public int RemainingCasualLeaves { get; set; }
        public int RemainingSickLeaves { get; set; }
    }
}
