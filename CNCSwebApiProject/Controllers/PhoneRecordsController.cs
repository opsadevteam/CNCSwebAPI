using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CNCSwebApiProject.Repository;
using Microsoft.AspNetCore.Authorization;

namespace CNCSwebApiProject.Controllers
{
    [Authorize]
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneRecordsController : ControllerBase
    {
        private readonly IPhoneRecordsRepository _phonerecordsRepository;
        private readonly IMapper _mapper;

        public PhoneRecordsController(IPhoneRecordsRepository phonerecordsRepository, IMapper mapper)
        {
           _phonerecordsRepository = phonerecordsRepository;
           _mapper = mapper;
        }

        /// <summary>
        /// Get all transactions.
        /// </summary>
        /// <returns>A list of transactions</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PhoneRecordsDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _phonerecordsRepository.GetPhoneRecordsTableAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionsDto = _mapper.Map<List<PhoneRecordsDto>>(transactions);
            return Ok(transactionsDto);
        }

        /// <summary>
        /// Soft delete a transaction.
        /// </summary>
        /// <param name="id">Transaction ID</param>
        /// <param name="deleteDto">Details for deletion</param>
        /// <returns>Response indicating success or failure</returns>
        [HttpPut("delete/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> SoftDelete(int id, [FromBody] PhoneRecordsDeleteDto deleteDto)
        {
            if (deleteDto == null || id != deleteDto.Id)
                return BadRequest(new { message = "Invalid request data" });

            var result = await _phonerecordsRepository.SoftDeleteAsync(id, deleteDto.IsDeleted);

            if (!result)
                return NotFound(new { message = "Transaction not found" });

            return Ok(new { message = "Transaction soft deleted successfully" });
        }

    }
}
