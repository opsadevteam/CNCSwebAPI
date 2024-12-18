using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.DescriptionDtos;
using CNCSwebApiProject.Dto.ProductDtos;
using CNCSwebApiProject.Services.DescriptionService;
using CNCSwebApiProject.Services.ProductService;
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
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync()
        {
            var obj = await _productService.GetProductsAsync();

            return obj.Any() ?
                Ok(obj) :
                NotFound("No data found.");
        }

        [HttpGet("{Product_Id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int Product_Id)
        {
            var obj = await _productService.GetProductAsync(Product_Id);

            return obj is not null ?
                Ok(obj) :
                NotFound($"User with ID {Product_Id} not found.");
        }

        // [HttpGet("{Product_Id}/Descriptionsold")]
        // public async Task<ActionResult<IEnumerable<DescriptionGetAndUpdateDto>>> GetDescriptionsByProductId(int Product_Id)
        // {
        //     var obj = await _descriptionService.GetAllByProductIdAsync(Product_Id);

        //     return Ok(obj ?? Enumerable.Empty<DescriptionGetAndUpdateDto>());
        // }


        [HttpGet("Descriptions")]
        public async Task<ActionResult<IEnumerable<ProductDescriptionsDto>>> GetProductsDescriptionsAsync()
        {
            var obj = await _productService.GetProductsDescriptionsAsync();

            return obj.Any() ?
                Ok(obj) :
                NotFound("No data found.");
        }

        [HttpGet("{Product_Id}/Descriptions")]
        public async Task<ActionResult<ProductDescriptionsDto>> GetProductDescriptionsAsync(int Product_Id)
        {
            var obj = await _productService.GetProductDescriptionsAsync(Product_Id);

            return obj is not null ?
                Ok(obj) :
                NotFound($"User with ID {Product_Id} not found.");
        }

        [HttpGet("{Product_Id}/Logs")]
        public async Task<ActionResult<ProductWithLogsDto>> GetProductWithLogsAsync(int Product_Id)
        {
            var obj = await _productService.GetProductWithLogsAsync(Product_Id);

            return obj is not null ?
                Ok(obj) :
                NotFound($"User with ID {Product_Id} not found.");
        }

        [HttpPost]
        public async Task<IActionResult> AddProductVendor(ProductCreateDto productVendorCreateDto)
        {
            if (productVendorCreateDto is null)
                return BadRequest("Invalid user account data.");

            if (await _productService.IsProductNameExists(productVendorCreateDto.Name!, 0))
                return Conflict("Product name is already taken.");

            var productId = await _productService.AddAProductsync(productVendorCreateDto);

            if (productId > 0)
                return Ok(new { Id = productId });
                
            return StatusCode(StatusCodes.Status500InternalServerError, "Error adding product.");
        }

        [HttpPut("{Product_Id}")]
        public async Task<IActionResult> UpdateDetailsAsync(int Product_Id, ProductUpdate Product_Name)
        {
            if (await _productService.IsProductNameExists(Product_Name.Name!, Product_Id!))
                return Conflict("Username is already taken.");

            var isUpdated = await _productService.UpdateProductAsync(Product_Id, Product_Name.Name);

            return isUpdated ?
                NoContent() :
                NotFound($"User with ID {Product_Id} not found.");
        }

        [HttpDelete("{Product_Id}")]
        public async Task<IActionResult> DeleteProduct(int Product_Id)
        {
            var isDeleted = await _productService.DeleteProductAsync(Product_Id);
            return isDeleted
                ? NoContent()
                : NotFound($"User with ID {Product_Id} not found.");
        }
    }
}
