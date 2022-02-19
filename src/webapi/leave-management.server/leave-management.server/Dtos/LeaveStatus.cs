using Newtonsoft.Json;

namespace leave_management.server.Dtos
{
    public interface ILeaveStatus
    {
        int TotalLeaves { get; set; }
        int Remaining { get; set; }
    }

    public class CasualLeaveStatus : ILeaveStatus
    {
        [JsonProperty("casual_leave_total")]
        public int TotalLeaves { get; set; }
        
        [JsonProperty("casual_leave_remaining")]
        public int Remaining { get; set; }
    }

    public class SickLeaveStatus : ILeaveStatus
    {
        [JsonProperty("sick_leave_total")]
        public int TotalLeaves { get; set; }

        [JsonProperty("sick_leave_remaining")]
        public int Remaining { get; set; }
    }
}
