using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace CNCSwebApiProject.Controllers
{
    [EnableCors("AllowOrigin")]
    //test commit
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransaction transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ITransaction>))]
        public IActionResult GetTransactions()
        {
            var transactions = _mapper.Map<List<TransactionDto>>(_transactionRepository.GetTransactions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transactions);
        }

        [HttpGet("{transactionId}")]
        [ProducesResponseType(200, Type = typeof(TblTransactions))]
        [ProducesResponseType(400)]
        public IActionResult GetTransaction(int transactionId)
        {
            if (!_transactionRepository.TransactionExists(transactionId))
                return NotFound();

            var transaction = _mapper.Map<TransactionDto>(_transactionRepository.GetTransaction(transactionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transaction);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTransaction([FromBody] TransactionDto transactionCreate)
        {
            if (transactionCreate == null)
                return BadRequest(ModelState);

            var transactions = _transactionRepository.GetTransactions()
                .Where(c => c.TransactionId.Trim().ToUpper() == transactionCreate.TransactionId.Trim().ToUpper())
                .FirstOrDefault();

            if (transactions != null)
            {
                ModelState.AddModelError("", "transaction already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionMap = _mapper.Map<TblTransactions>(transactionCreate);

            if (!_transactionRepository.CreateTransaction(transactionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpPut("{transactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTransaction(int transactionId, [FromBody] TransactionDto updatedTransaction)

        {

            if (updatedTransaction == null)
                return BadRequest(ModelState);

            if (transactionId != updatedTransaction.Id)
                return BadRequest(ModelState);

            if (!_transactionRepository.TransactionExists(transactionId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionMap = _mapper.Map<TblTransactions>(updatedTransaction);

            if (!_transactionRepository.UpdateTransaction(transactionMap))
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
        public IActionResult DeleteTransaction(int transactionId)
        {
            if (!_transactionRepository.TransactionExists(transactionId))
            {
                return NotFound();
            }

            var transactionToDelete = _transactionRepository.GetTransaction(transactionId);
            if (!_transactionRepository.DeleteTransaction(transactionToDelete))

            {
                ModelState.AddModelError("", "Something went wrong deleting Transaction");
            }
            return NoContent();
        }

    }
}
