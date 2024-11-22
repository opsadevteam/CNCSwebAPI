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
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccount _userAccountRepository;
        private readonly IMapper _mapper;

        public UserAccountController(IUserAccount userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IUserAccount>))]
        public IActionResult GetUserAccounts()
        {
            var userAccounts = _mapper.Map<List<UserAccountDto>>(_userAccountRepository.GetUserAccounts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userAccounts);
        }
    }
}
