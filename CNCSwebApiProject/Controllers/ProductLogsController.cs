using CNCSwebApiProject.Dto.ProductLogDtos;
using CNCSwebApiProject.Services.ProductLogService;
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
    public class ProductLogsController(IProductLogService _productLogService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProductVendor(ProductLogDto productLogDto)
        {
            if (productLogDto is null)
                return BadRequest("Invalid data.");

            var isAdded = await _productLogService.AddProductLogAsync(productLogDto);
            return isAdded ?
                NoContent() :
                StatusCode(StatusCodes.Status500InternalServerError, "Error adding product.");
        }
    }
}