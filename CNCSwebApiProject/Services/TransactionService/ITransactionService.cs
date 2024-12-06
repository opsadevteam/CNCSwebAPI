using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsAsync();
        Task<TransactionDto> GetTransactionAsync(int id);
        Task<IEnumerable<TransactionDetaildDto>> GetTransactionCustomerIdAsync(string customerId);
        Task<bool> CreateTransactionAsync(TransactionDto transactionDto);
        Task<bool> TransactionExistsAsync(int transactionId);
        Task<bool> TransactionExistsCustomerIdAsync(string customerId);
        Task<bool> UpdateTransactionAsync(TransactionDto transactionDto);
        Task<bool> DeleteTransactionAsync(TransactionDto transactionDto);
        Task<bool> SaveAsync();
    }
}
