using leave_management.server.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace leave_management.server
{
    public static class GenericCommands
    {
        
        [FunctionName(nameof(GetRemainingLeaves))]
        public static IActionResult GetRemainingLeaves([HttpTrigger(AuthorizationLevel.Anonymous,
        "GET",Route = null)] HttpRequest request,
        ILogger logger)
        {
            logger.LogInformation("Requesting for leave status");
            var random = new Random();

            // Mock the leave status
            var leaves = new LeaveStatus
            {
                TotalCasualLeaves = 20,
                TotalSickLeaves = 20,
                RemainingCasualLeaves = random.Next(0, 20),
                RemainingSickLeaves = random.Next(0, 20),
            };

            return new OkObjectResult(leaves);
        }


        [FunctionName(nameof(RequestLeave))]
        public static async Task<IActionResult> RequestLeave(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request,
            ILogger logger)
        {
            logger.LogInformation("Parsing Leave Request Information");
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<LeaveRequest>(requestBody);

            logger.LogInformation($"Marking {data.Type} Leave from {data.StartDate} to {data.EndDate}");

            return new OkObjectResult("Leave Requested");
        }
    }
    
}


