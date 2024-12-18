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
    public class TransactionLogsController : ControllerBase
    {
        private readonly ITransactionLogsRepository _transactionlogsRepository;
        private readonly IMapper _mapper;

        public TransactionLogsController(ITransactionLogsRepository transactionlogsRepository, IMapper mapper)
        {
            _transactionlogsRepository = transactionlogsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all transactions.
        /// </summary>
        /// <returns>A list of transactions</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TransactionLogsDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTransactionsLogs()
        {
            var transactions = await _transactionlogsRepository.GetTransactionLogsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionsDto = _mapper.Map<List<TransactionLogsDto>>(transactions);
            return Ok(transactionsDto);
        }

        /// <summary>
        /// Get transaction logs by transaction ID.
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns>A list of transaction logs or an error response</returns>
        [HttpGet("id/{transactionId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TransactionLogsDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTransactionLogsByTransactionId(string transactionId)
        {
            if (string.IsNullOrWhiteSpace(transactionId))
                return BadRequest(new { message = "Transaction ID cannot be null or empty." });

            var logs = await _transactionlogsRepository.GetLogsbyTransactionIdAsync(transactionId);

            if (logs == null || !logs.Any())
                return NotFound(new { message = $"No logs found for transaction ID '{transactionId}'." });

            var logsDto = _mapper.Map<List<TransactionLogsDto>>(logs);

            return Ok(logsDto);
        }

    }
}
