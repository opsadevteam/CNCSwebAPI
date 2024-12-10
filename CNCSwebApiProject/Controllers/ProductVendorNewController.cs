using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.ProductVendorDtos;
using CNCSwebApiProject.Services.ProductVendorService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSwebApiProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductVendorNewController(IProductVendorServiceNew _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVendorNewDto>>> GetUserAccountsAsync()
        {
            var obj = await _productService.GetAllAsync();

            return obj.Any() ?
                Ok(obj) :
                NotFound("No data found.");
        }

        [HttpGet("{Product_Id}")]
        public async Task<ActionResult<ProductVendorNewDto>> GetUserAccountAsync(int Product_Id)
        {
            var obj = await _productService.GetAsync(Product_Id);

            return obj is not null ?
                Ok(obj) :
                NotFound($"User with ID {Product_Id} not found.");
        }

        [HttpPost]
        public async Task<IActionResult> AddProductVendor(ProductVendorCreateDto productVendorCreateDto)
        {
            if (productVendorCreateDto is null) 
                return BadRequest("Invalid user account data.");

            if (await _productService.IsNameExists(productVendorCreateDto.Name!, 0))
                return Conflict("Product name is already taken.");

            var isAdded = await _productService.AddAsync(productVendorCreateDto);
            return isAdded ?
                NoContent() :
                StatusCode(StatusCodes.Status500InternalServerError, "Error adding product.");
        }

        [HttpPut("{Product_Id}")]
        public async Task<IActionResult> UpdateDetailsAsync(int Product_Id, ProductVendorUpdateDto productVendorUpdateDto)
        {
            if (await _productService.IsNameExists(productVendorUpdateDto.Name!, Product_Id!))
                return Conflict("Username is already taken.");

            var isUpdated = await _productService.UpdateDetailsAsync(Product_Id, productVendorUpdateDto);

            return isUpdated ?
                NoContent() : 
                NotFound($"User with ID {Product_Id} not found.");
        }
    }
}
