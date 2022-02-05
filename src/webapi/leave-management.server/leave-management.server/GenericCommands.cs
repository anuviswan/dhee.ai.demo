using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace leave_management.server
{
    public static class GenericCommands
    {
        [FunctionName(nameof(SayHello))]
        public static async Task<IActionResult> SayHello(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string responseMessage = $"Hello {name} !!";

            return new OkObjectResult(responseMessage);
        }
    }
}
