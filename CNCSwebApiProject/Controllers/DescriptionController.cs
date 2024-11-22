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
    public class DescriptionController : ControllerBase
    {
        private readonly IDescription _descriptionRepository;
        private readonly IMapper _mapper;

        public DescriptionController(IDescription descriptionRepository, IMapper mapper)
        {
            _descriptionRepository = descriptionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IDescription>))]
        public IActionResult GetDescriptions()
        {
            var descriptions = _mapper.Map<List<DescriptionDto>>(_descriptionRepository.GetDescriptions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(descriptions);
        }

    }
}
