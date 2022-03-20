using leave_management.server.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.server
{
    public static class GenericCommands
    {
        [FunctionName(nameof(RetrieveCasualLeaveStatus))]
        public static IActionResult RetrieveCasualLeaveStatus([HttpTrigger(AuthorizationLevel.Anonymous,
        "POST",Route = null)] HttpRequest request,
        ILogger logger)
        {
            logger.LogInformation("Requesting for leave status");
            var random = new Random();

            // Mock the leave status
            var leaves = new CasualLeaveStatus
            {
                TotalLeaves = 20,
                Remaining = random.Next(0, 20),
            };

            return new OkObjectResult(new DheeResponseDto<CasualLeaveStatus>
            {
                Success = true,
                Result = leaves,
                ErrorMessageKey = String.Empty,
                ResetList = Enumerable.Empty<string>()
            }) ;
        }


        [FunctionName(nameof(RetrieveSickLeaveStatus))]
        public static IActionResult RetrieveSickLeaveStatus([HttpTrigger(AuthorizationLevel.Anonymous,
        "POST",Route = null)] HttpRequest request,
        ILogger logger)
        {
            logger.LogInformation("Requesting for leave status");
            var random = new Random();

            // Mock the leave status
            var leaves = new SickLeaveStatus
            {
                TotalLeaves = 20,
                Remaining = random.Next(0, 20),
            };

            return new OkObjectResult(new DheeResponseDto<SickLeaveStatus>
            {
                Success = true,
                Result = leaves,
                ErrorMessageKey = String.Empty,
                ResetList = Enumerable.Empty<string>()
            });
        }


        [FunctionName(nameof(RequestLeave))]
        public static async Task<IActionResult> RequestLeave(
            [HttpTrigger(AuthorizationLevel.Function, "POST", Route = null)] HttpRequest request,
            ILogger logger)
        {
            logger.LogInformation("Parsing Leave Request Information");

            var data = new
            {
                StartDate = DateTime.Parse(request.Query["startDate"]),
                EndDate = DateTime.Parse(request.Query["endDate"]),
                Reason = request.Query["leaveReason"]
            };

            logger.LogInformation($"Marking {data.Reason} Leave from {data.StartDate} to {data.EndDate}");

            return new OkObjectResult(new DheeResponseDto<LeaveRequestResponse>
            {
                Success = true,
                Result = new LeaveRequestResponse { IsRequested = true},
                ErrorMessageKey = String.Empty,
                ResetList = Enumerable.Empty<string>()
            });
        }
    }
    
}


