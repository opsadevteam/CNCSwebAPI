using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CNCSwebApiProject.Repository;

namespace CNCSwebApiProject.Controllers
{
    [EnableCors("AllowOrigin")]

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductVendorController : ControllerBase
    {
        private readonly IProductVendor _productVendorRepository;
        private readonly IMapper _mapper;

        public ProductVendorController(IProductVendor productVendorRepository, IMapper mapper)
        {
            _productVendorRepository = productVendorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IProductVendor>))]
        public IActionResult GetProductVendors()
        {
            var productVendors = _mapper.Map<List<ProductVendorDto>>(_productVendorRepository.GetProductVendors());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(productVendors);
        }

        [HttpGet("{productVendorId}")]
        [ProducesResponseType(200, Type = typeof(TblProductVendor))]
        [ProducesResponseType(400)]
        public IActionResult GetProductVendor(int productVendorId)
        {
            if (!_productVendorRepository.ProductVendorExists(productVendorId))
                return NotFound();

            var productVendor = _mapper.Map<ProductVendorDto>(_productVendorRepository.GetProductVendor(productVendorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(productVendor);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProductVendor([FromBody] ProductVendorDto productVendorCreate)
        {
            if (productVendorCreate == null)
                return BadRequest(ModelState);

            var productVendors = _productVendorRepository.GetProductVendors()
                .Where(c => c.ProductVendor.Trim().ToUpper() == productVendorCreate.ProductVendor.Trim().ToUpper())
                .FirstOrDefault();

            if (productVendors != null)
            {
                ModelState.AddModelError("", "ProductVendor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productVendorMap = _mapper.Map<TblProductVendor>(productVendorCreate);

            if (!_productVendorRepository.CreateProductVendor(productVendorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpPut("{productVendorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProductVendor(int productVendorId, [FromBody] ProductVendorDto updatedProductVendor)
        {

            if (updatedProductVendor == null)
                return BadRequest(ModelState);
            if (productVendorId != updatedProductVendor.Id)
                return BadRequest(ModelState);
            if (!_productVendorRepository.ProductVendorExists(productVendorId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var productVendorMap = _mapper.Map<TblProductVendor>(updatedProductVendor);
            if (!_productVendorRepository.UpdateProductVendor(productVendorMap))
            {
                ModelState.AddModelError("", "Something went wrong Updating Product Vendor");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


        [HttpDelete("{productVendorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProductVendor(int productVendorId)
        {
            if (!_productVendorRepository.ProductVendorExists(productVendorId))
            {
                return NotFound();
            }

            var productVendorToDelete = _productVendorRepository.GetProductVendor(productVendorId);
            if (!_productVendorRepository.DeleteProductVendor(productVendorToDelete))

            {
                ModelState.AddModelError("", "Something went wrong deleting Product Vendor");
            }
            return NoContent();
        }
    }
}
