using CNCSwebApiProject.Dto.ProductDescriptionDtos;
using CNCSwebApiProject.Services.DescriptionService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSwebApiProject.Controllers;

[EnableCors("AllowOrigin")]
[Route("api/v1/[controller]")]
[ApiController]
public class ProductDescriptionController(IProductDescriptionService _prodDescService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProductDescription(ProductDescriptionCreateDto productDescriptionCreateDto)
    {
        if (productDescriptionCreateDto is null)
            return BadRequest("Invalid data.");

        var isAdded = await _prodDescService.AddAsync(productDescriptionCreateDto);
        return isAdded ?
            NoContent() :
            StatusCode(StatusCodes.Status500InternalServerError, "Error adding description.");
    }

    [HttpPut("{ProductDescription_Id}")]
    public async Task<ActionResult> UpdateProductDescription(int ProductDescription_Id, ProductDescriptionGetAndUpdateDto productDescriptionUpdateDto)
    {
        var isUpdated = await _prodDescService.UpdateDetailsAsync(ProductDescription_Id, productDescriptionUpdateDto);

        return isUpdated ?
            NoContent() :
            NotFound($"Data with {ProductDescription_Id} not found.");
    }

    [HttpDelete("{ProductDescription_Id}")]
    public async Task<IActionResult> DeleteUserAccountAsync(int ProductDescription_Id)
    {
        var isDeleted = await _prodDescService.DeleteAsync(ProductDescription_Id);
        return isDeleted
            ? NoContent()
            : NotFound($"User with ID {ProductDescription_Id} not found.");
    }
}
