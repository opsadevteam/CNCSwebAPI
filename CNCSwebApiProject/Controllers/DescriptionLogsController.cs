using CNCSwebApiProject.Dto.DescriptionLogDtos;
using CNCSwebApiProject.Services.DescriptionLogService;
using CNCSwebApiProject.Services.DescriptionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSwebApiProject.Controllers
{
    [Authorize]
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DescriptionLogsController(IDescriptionLogService _descriptionLogService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddDescriptionLog(DescriptionLogDto descriptionLogDto)
        {
            if (descriptionLogDto is null)
                return BadRequest("Invalid data.");

            var isAdded = await _descriptionLogService.AddDescriptionLogAsync(descriptionLogDto);
            return isAdded ?
                NoContent() :
                StatusCode(StatusCodes.Status500InternalServerError, "Error adding product.");
        }
    }
}
