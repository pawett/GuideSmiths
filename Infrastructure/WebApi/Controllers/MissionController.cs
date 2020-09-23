using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MartianRobots.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MissionController : ControllerBase
    {

        private readonly ILogger<MissionController> _logger;

        public MissionController(ILogger<MissionController> logger)
        {
            _logger = logger;
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Post()
        {
            InputData inputData;

            try
            {
                string inputDataRaw = string.Empty;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    inputDataRaw = await reader.ReadToEndAsync();
                }
                inputData = InputHelper.ReadInputData(inputDataRaw);
                var missionControl = new MissionControlService(inputData.UpperRightCoordinate);
                var results = missionControl.ExecuteMission(inputData.RobotInstructions);
                return Ok(OutputHelper.FormatOutput(results));
            }
            catch (ArgumentException ex)
            {
                var message = "Invalid input. Check log for more details";
                _logger.LogError($"Invalid input: {ex}");
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Unexpected error. Check log for more details", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };

                return Ok("Unexpected error");
                //throw new HttpResponseException(response);
            }
        }
    }
}
