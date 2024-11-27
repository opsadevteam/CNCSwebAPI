using System.Collections.Generic;
using System.Threading.Tasks;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IEmailRecordsRepository
    {
        Task<ICollection<TblTransactions>> GetEmailRecordsTableAsync();
        Task<TblTransactions> GetTransactionAsync(int id);
        Task<bool> TransactionExistsAsync(int transactionId);
        Task<bool> SoftDeleteAsync(int id, bool? isDeleted);
        Task<bool> SaveAsync();
    }
}
