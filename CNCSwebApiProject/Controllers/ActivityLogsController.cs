using CNCSapi.Interface;
using CNCSapi.Repository;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;
using CNCSwebApiProject.Services.ActivityLogService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSapi.Controllers
{
    [Authorize]
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActivityLogsController(IActivityLogService _activityLogService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLogGetDto>>> GetActivityLogs()
        {
            var logs = await _activityLogService.GetAllAsync();

            return logs.Any() ?
                Ok(logs) :
                NotFound("No data found.");
        }
    }
}
