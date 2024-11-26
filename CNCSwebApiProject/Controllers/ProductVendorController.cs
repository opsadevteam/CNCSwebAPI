using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CNCSwebApiProject.Repository;
using CNCSwebApiProject.Services.ProductVendorService;


namespace CNCSwebApiProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductVendorController : ControllerBase
    {
        private readonly IProductVendorService _productVendorService;

        public ProductVendorController(IProductVendorService productVendorService)
        {
            _productVendorService = productVendorService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IProductVendorService>))]
        public async Task<IActionResult> GetProductVendors()
        {
            var productVendorsDto = await _productVendorService.GetProductVendorsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(productVendorsDto);
        }

        [HttpGet("{productVendorId}")]
        [ProducesResponseType(200, Type = typeof(TblProductVendor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProductVendor(int productVendorId)
        {
            if (!await _productVendorService.ProductVendorExistsAsync(productVendorId))
                return NotFound();
            var productVendorDto = await _productVendorService.GetProductVendorAsync(productVendorId);
            if (productVendorDto == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(productVendorDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateProductVendor([FromBody] ProductVendorDto productVendorDto)
        {
            if (productVendorDto == null)
            {
                return BadRequest(ModelState);
            }
            var result = await _productVendorService.CreateProductVendorAsync(productVendorDto);
            if (!result)
            {
                ModelState.AddModelError("", "ProductVendor already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (result)
            {
                return CreatedAtAction(nameof(GetProductVendor), new { productVendorId = productVendorDto.Id }, productVendorDto);
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }


        [HttpPut("{productVendorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateProductVendor(int productVendorId, [FromBody] ProductVendorDto updatedProductVendor)
        {
            if (updatedProductVendor == null)
                return BadRequest(ModelState);
            if (productVendorId != updatedProductVendor.Id)
                return BadRequest(ModelState);
            if (!await _productVendorService.ProductVendorExistsAsync(productVendorId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _productVendorService.UpdateProductVendorAsync(updatedProductVendor))
            {
                ModelState.AddModelError("", "Something went wrong Updating Transaction");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{productVendorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProductVendor(int productVendorId)
        {
            if (!await _productVendorService.ProductVendorExistsAsync(productVendorId))
            {
                return NotFound();
            }
            var productVendorToDelete = await _productVendorService.GetProductVendorAsync(productVendorId);
            if (!await _productVendorService.DeleteProductVendorAsync(productVendorToDelete))

            {
                ModelState.AddModelError("", "Something went wrong deleting ProductVendor");
            }
            return NoContent();
        }
    }
}
