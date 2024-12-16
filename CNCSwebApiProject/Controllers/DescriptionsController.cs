using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.DescriptionDtos;
using CNCSwebApiProject.Services.DescriptionService;
using CNCSwebApiProject.Services.ProductService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSwebApiProject.Controllers;

[EnableCors("AllowOrigin")]
[Route("api/v1/[controller]")]
[ApiController]
public class DescriptionsController(IDescriptionService _prodDescService, IProductService _productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DescriptionDto>>> GetDescriptionsAsync()
    {
        var obj = await _prodDescService.GetDescriptionsAsync();

        return obj.Any() ?
            Ok(obj) :
            NotFound("No data found.");
    }

    // [HttpGet("by-product/{productId:int}")]
    // public async Task<ActionResult<IEnumerable<DescriptionDto>>> GetDescriptionsByProductIdAsync(int productId)
    // {
    //     var descriptions = await _prodDescService.GetAllByProductIdAsync(productId);

    //     return descriptions.Any()
    //         ? Ok(descriptions)
    //         : NotFound($"No descriptions found for Product ID {productId}.");
    // }

    [HttpGet("{Description_Id:int}")]
    public async Task<ActionResult<DescriptionDto>> GetDescriptionAsync(int Description_Id)
    {
        var obj = await _prodDescService.GetDescriptionAsync(Description_Id);

        return obj is not null ?
            Ok(obj) :
            NotFound($"Data with ID {Description_Id} not found.");
    }

    [HttpGet("{Description_Id}/Logs")]
    public async Task<ActionResult<DescriptionWithLogsDto>> GetDescriptionWithLogs(int Description_Id)
    {
        var obj = await _prodDescService.GetDescriptionWithLogsAsync(Description_Id);

        return obj is not null ?
            Ok(obj) :
            NotFound($"User with ID {Description_Id} not found.");
    }

    [HttpPost]
    public async Task<IActionResult> AddDescription(ProductDescriptionCreateDto productDescriptionCreateDto)
    {
        if (productDescriptionCreateDto is null)
            return BadRequest("Invalid data.");

        if (await _prodDescService.IsDescriptionExists(0, productDescriptionCreateDto.Description, productDescriptionCreateDto.ProductVendorId))
            return Conflict("Description is already taken.");

        var isAdded = await _prodDescService.AddDescriptionAsync(productDescriptionCreateDto);
        return isAdded ?
            NoContent() :
            StatusCode(StatusCodes.Status500InternalServerError, "Error adding description.");
    }

    [HttpPut("{Description_Id:int}")]
    public async Task<ActionResult> UpdateDescription(int Description_Id, [FromBody] DescriptionDto descriptionDto, [FromQuery] int Product_Id)
    {
        var product = await _productService.GetProductAsync(Product_Id);

        if (product == null) return NotFound("Product not found");

        if (await _prodDescService.IsDescriptionExists(Description_Id, descriptionDto.Description, Product_Id))
            return Conflict("Description is already taken.");

        var isUpdated = await _prodDescService.UpdateDescriptionAsync(Description_Id, descriptionDto);

        return isUpdated ?
            NoContent() :
            NotFound($"Data with {Description_Id} not found.");
    }

    [HttpDelete("{Description_Id:int}")]
    public async Task<IActionResult> DeleteDescriptionAsync(int Description_Id)
    {
        var isDeleted = await _prodDescService.DeleteDescriptionAsync(Description_Id);
        return isDeleted
            ? NoContent()
            : NotFound($"User with ID {Description_Id} not found.");
    }
}
