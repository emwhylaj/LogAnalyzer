using LogAnalyzerLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LogAnalyzerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ICount _count;

        public LogsController(ICount count)
        {
            _count = count;
        }

        [HttpGet]
        [Route("Count")]
        public IActionResult GetLogsCount(string path)
        {
            return Ok(_count.CountFiles(path));
        }

        [HttpGet]
        [Route("CountByPeriod")]
        public IActionResult GetCountByDates(string path, DateTime startDate, DateTime endDate)
        {
            return Ok(_count.CountFilesByDate(path, startDate, endDate));
        }

        [HttpDelete]
        public IActionResult DeleteLogs(string path, DateTime startDate, DateTime endDate)
        {
            var success = _count.DeleteFiles(path, startDate, endDate);

            if (!success) return NotFound(new { Success = false, Message = "No files within that period" });

            return StatusCode(StatusCodes.Status204NoContent, new { Success = true, Message = "Log files deleted successfully" });
        }
    }
}