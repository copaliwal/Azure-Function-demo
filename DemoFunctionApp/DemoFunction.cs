using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DemoFunctionApp
{
    public class DemoFunction
    {
        private readonly IEmployeeService _employeeService;

        public DemoFunction(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [FunctionName("DemoFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "run")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "employee")] HttpRequest req,
            ILogger log)
        {
            var employees = _employeeService.GetAllEmployees();

            return (ActionResult)new OkObjectResult(employees);
        }

        [FunctionName("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "employee/{id}")] HttpRequest req, 
            int id,
            ILogger log)
        {
            var employees = _employeeService.GetEmployeeById(id);
            return (ActionResult)new OkObjectResult(employees);
        }

    }
}
