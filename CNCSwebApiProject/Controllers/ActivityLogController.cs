using CNCSapi.Interface;
using CNCSapi.Repository;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSapi.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController(IActivityLogRepository _activityLogRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblActivityLog>>> GetActivityLogs()
        {
            var logs = await _activityLogRepository.GetAllAsync();

            return logs.Any() ?
                Ok(logs) :
                NotFound("No data found.");
        }
    }
}
