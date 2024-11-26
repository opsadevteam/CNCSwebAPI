using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface ITransactionRepository
    {
        Task<ICollection<TblTransactions>> GetTransactionsAsync();
        Task<TblTransactions> GetTransactionAsync(int id);
        Task<bool> TransactionExistsAsync(int transactionId);
        Task<bool> CreateTransactionAsync(TblTransactions transaction);
        Task<bool> UpdateTransactionAsync(TblTransactions transaction);
        Task<bool> DeleteTransactionAsync(TblTransactions transaction);
        Task<bool> SaveAsync();
    }
}
