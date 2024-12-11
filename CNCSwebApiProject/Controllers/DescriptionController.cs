using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CNCSwebApiProject.Repository;
using CNCSwebApiProject.Services.DescriptionService;
using Microsoft.AspNetCore.Authorization;


namespace CNCSwebApiProject.Controllers
{
    [Authorize]
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionService _descriptionService;

        public DescriptionController(IDescriptionService descriptionService)
        {
            _descriptionService = descriptionService;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IDescriptionService>))]
        public async Task<IActionResult> GetDescriptions()
        {
            var descriptionsDto = await _descriptionService.GetDescriptionsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(descriptionsDto);
        }

        [HttpGet("{descriptionId}")]
        [ProducesResponseType(200, Type = typeof(TblDescriptions))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDescription(int descriptionId)
        {
            if (!await _descriptionService.DescriptionExistsAsync(descriptionId))
                return NotFound();
            var descriptionDto = await _descriptionService.GetDescriptionAsync(descriptionId);
            if (descriptionDto == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(descriptionDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateDescription([FromBody] DescriptionDto descriptionDto)
        {
            if (descriptionDto == null)
            {
                return BadRequest(ModelState);
            }
            var result = await _descriptionService.CreateDescriptionAsync(descriptionDto);
            if (!result)
            {
                ModelState.AddModelError("", "Decription already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (result)
            {
                return CreatedAtAction(nameof(GetDescription), new { descriptionId = descriptionDto.Id }, descriptionDto);
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        [HttpPut("{descriptionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateDescription(int descriptionId, [FromBody] DescriptionDto updatedDescription)
        {
            if (updatedDescription == null)
                return BadRequest(ModelState);
            if (descriptionId != updatedDescription.Id)
                return BadRequest(ModelState);
            if (!await _descriptionService.DescriptionExistsAsync(descriptionId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _descriptionService.UpdateDescriptionAsync(updatedDescription))
            {
                ModelState.AddModelError("", "Something went wrong Updating Description");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{descriptionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteDescription(int descriptionId)
        {
            if (!await _descriptionService.DescriptionExistsAsync(descriptionId))
            {
                return NotFound();
            }
            var descriptionToDelete = await _descriptionService.GetDescriptionAsync(descriptionId);
            if (!await _descriptionService.DeleteDescriptionAsync(descriptionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Description");
            }
            return NoContent();
        }

    }
}
