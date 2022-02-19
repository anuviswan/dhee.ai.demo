using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.server.Dtos
{
    internal class LeaveRequestResponse
    {
        [JsonProperty("is_requested")]
        public bool IsRequested { get; set; }
    }
}
