using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.DescriptionDtos;
using CNCSwebApiProject.Dto.ProductDtos;
using CNCSwebApiProject.Services.DescriptionService;
using CNCSwebApiProject.Services.ProductService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSwebApiProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService, IDescriptionService _descriptionService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
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

        [HttpGet("{Product_Id}/Descriptions")]
        public async Task<ActionResult<IEnumerable<DescriptionGetAndUpdateDto>>> GetDescriptionsByProductId(int Product_Id)
        {
            var obj = await _descriptionService.GetAllByProductIdAsync(Product_Id);

            return obj.Any() ?
                Ok(obj) :
                NotFound("No data found.");
        }

        // [HttpGet("with-descriptions")]
        // public async Task<ActionResult<IEnumerable<ProductWithDescriptionDto>>> GetAllProdWithDescAsync()
        // {
        //     var obj = await _productService.GetAllProdWithDescAsync();

        //     return obj.Any() ?
        //         Ok(obj) :
        //         NotFound("No data found.");
        // }

        // [HttpGet("with-descriptions/{Product_Id}")]
        // public async Task<ActionResult<ProductDto>> GetProdWithDescAsync(int Product_Id)
        // {
        //     var obj = await _productService.GetProdWithDescAsync(Product_Id);

        //     return obj is not null ?
        //         Ok(obj) :
        //         NotFound($"User with ID {Product_Id} not found.");
        // }

        [HttpPost]
        public async Task<IActionResult> AddProductVendor(ProductCreateDto productVendorCreateDto)
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
        public async Task<IActionResult> UpdateDetailsAsync(int Product_Id, ProductUpdateDto productVendorUpdateDto)
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
