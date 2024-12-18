using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IPhoneRecordsRepository
    {
        Task<ICollection<TblTransactions>> GetPhoneRecordsTableAsync();
        Task<TblTransactions> GetTransactionAsync(int id);
        Task<bool> TransactionExistsAsync(int transactionId);
        Task<bool> SoftDeleteAsync(int id, bool isDeleted);
        Task<bool> SaveAsync();
    }
}
