using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface ITransactionLogsRepository
    {
        Task<ICollection<TblTransactionLogs>> GetTransactionLogsAsync();
        Task<ICollection<TblTransactionLogs>> GetLogsbyTransactionIdAsync(string transactionId);
        Task<bool> TransactionLogsExistsAsync(int transactionId);  
        Task<bool> SaveAsync();
    }
}
