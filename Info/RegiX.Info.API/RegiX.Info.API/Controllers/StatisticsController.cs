using Microsoft.AspNetCore.Mvc;
using RegiX.Info.API.DTOs;
using RegiX.Info.Services.Contracts;
using System;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/statistics")]//required for default versioning
    [Route("api/v{version:apiVersion}/statistics")]
    public class StatisticsController : Controller
    {
        protected IStatisticsService service;

        public StatisticsController(IStatisticsService aService)
        {
            service = aService;
        }


        //TimeFrames: day, hour, week, month, dayerror, hourerror, weekerror, montherror
        [HttpPost("")]
        public IActionResult Get([FromBody] StatisticsInDto inputModel)
        {
            var results = this.service.CallStatisticsProcedure(inputModel.TimeFrame, inputModel.ShowError);
            return Ok(results);
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthly([FromHeader] string month)
        {
            if (!string.IsNullOrEmpty(month) &&
                 DateTime.TryParseExact(month, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out _)
                )
            {
                var result = this.service.GetMonthRecords(month);
                return Ok(
                    new
                    {
                        result = new[]
                        {
                       new
                       {
                           month = month,
                           value = result
                       }
                        }
                    }
                );
            }
            else
            {
                return BadRequest(new
                {
                    error = "month header missing or incorrect format. Correct format is yyyy-MM"
                });
            }
        }
    }
}