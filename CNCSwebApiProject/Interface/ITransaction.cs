using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface ITransaction
    {
        ICollection<TblTransactions> GetTransactions();
        TblTransactions GetTransaction(int id);
        bool TransactionExists(int transactionId);
        bool CreateTransaction(TblTransactions transaction);
        bool UpdateTransaction(TblTransactions transaction);
        bool DeleteTransaction(TblTransactions transaction);
        bool Save();
    }
}
