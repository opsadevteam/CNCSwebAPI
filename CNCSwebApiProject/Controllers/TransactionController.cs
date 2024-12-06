using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CNCSwebApiProject.Services.TransactionService;
using CNCSwebApiProject.Repository;


namespace CNCSwebApiProject.Controllers
{
    [EnableCors("AllowOrigin")] //tag1
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ITransactionService>))]
        public async Task<IActionResult> GetTransactions()
        {
            var transactionsDto = await _transactionService.GetTransactionsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(transactionsDto);
        }

        [HttpGet("{transactionId}")]
        [ProducesResponseType(200, Type = typeof(TblTransactions))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTransaction(int transactionId)
        {
            if (!await _transactionService.TransactionExistsAsync(transactionId))
                return NotFound();
            var transactionDto = await _transactionService.GetTransactionAsync(transactionId);
            if (transactionDto == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(transactionDto);
        }

        [HttpGet("CustomerId/{customerId}")]
        [ProducesResponseType(200, Type = typeof(TblTransactions))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTransactionCustomerId(string customerId)
        {
            if (!await _transactionService.TransactionExistsCustomerIdAsync(customerId))
                return NotFound();
            var transactionDto = await _transactionService.GetTransactionCustomerIdAsync(customerId);
            if (transactionDto == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(transactionDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto transactionDto)
        {
            if (transactionDto == null)
            {
                return BadRequest(ModelState);
            }
            var result = await _transactionService.CreateTransactionAsync(transactionDto);
            if (!result)
            {
                ModelState.AddModelError("", "Transaction already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (result)
            {
                return CreatedAtAction(nameof(GetTransaction), new { transactionId = transactionDto.Id }, transactionDto);
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }


        [HttpPut("{transactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTransaction(int transactionId, [FromBody] TransactionDto updatedTransaction)
        {
            if (updatedTransaction == null)
                return BadRequest(ModelState);
            if (transactionId != updatedTransaction.Id)
                return BadRequest(ModelState);
            if (!await _transactionService.TransactionExistsAsync(transactionId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _transactionService.UpdateTransactionAsync(updatedTransaction))
            {
                ModelState.AddModelError("", "Something went wrong Updating Transaction");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTransaction(int transactionId)
        {
            if (!await _transactionService.TransactionExistsAsync(transactionId))
            {
                return NotFound();
            }
            var transactionToDelete = await _transactionService.GetTransactionAsync(transactionId);
            if (!await _transactionService.DeleteTransactionAsync(transactionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Transaction");
            }
            return NoContent();
        }

    } 
}
