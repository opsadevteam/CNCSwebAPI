using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Repository
{
    public class TransactionRepository : ITransaction
    {
        private readonly CncssystemContext _context;

        public TransactionRepository(CncssystemContext context)
        {
            _context = context;
        }
        public bool CreateTransaction(TblTransactions transaction)
        {
            _context.Add(transaction);

            return Save();
        }

        public bool DeleteTransaction(TblTransactions transaction)
        {
            _context.Remove(transaction);

            return Save();
        }

        public TblTransactions GetTransaction(int id)
        {
            return _context.TblTransactions.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<TblTransactions> GetTransactions()
        {
            return _context.TblTransactions.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransactionExists(int transactionId)
        {
            return _context.TblTransactions.Any(p => p.Id == transactionId);
        }

        public bool UpdateTransaction(TblTransactions transaction)
        {
            _context.Update(transaction);
            return Save();
        }
    }
}
