using System.Web.Http.ModelBinding;
using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;



namespace CNCSwebApiProject.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateTransactionAsync(TransactionDto transactionDto)
        {
            var transactionsAsync = await _transactionRepository.GetTransactionsAsync();
            var transactions = transactionsAsync
                .Where(c => c.TransactionId.Trim().ToUpper() == transactionDto.TransactionId.Trim().ToUpper())
                .FirstOrDefault();
            if (transactions != null) return false;
            var transaction = _mapper.Map<TblTransactions>(transactionDto);
            return await _transactionRepository.CreateTransactionAsync(transaction);
        }

        public async Task<bool> DeleteTransactionAsync(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<TblTransactions>(transactionDto);
            return await _transactionRepository.DeleteTransactionAsync(transaction);
        }

        public async Task<TransactionDto> GetTransactionAsync(int id)
        {
            var transaction = await _transactionRepository.GetTransactionAsync(id);
            if (transaction == null) return null;
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _transactionRepository.SaveAsync();
            return result;

        }

        public async Task<bool> TransactionExistsAsync(int transactionId)
        {
            return await _transactionRepository.TransactionExistsAsync(transactionId);
        }

        public async Task<bool> UpdateTransactionAsync(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<TblTransactions>(transactionDto);
            return await _transactionRepository.UpdateTransactionAsync(transaction);
        }
    }
}
