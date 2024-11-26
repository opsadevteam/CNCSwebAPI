using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CncssystemContext _context;

        public TransactionRepository(CncssystemContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTransactionAsync(TblTransactions transaction)
        {
            await _context.TblTransactions.AddAsync(transaction);
            return await SaveAsync();
        }

        public async Task<bool> DeleteTransactionAsync(TblTransactions transaction)
        {
            var existingTransaction = await _context.TblTransactions.FindAsync(transaction.Id);
            if (existingTransaction != null)
            {
                _context.Entry(existingTransaction).State = EntityState.Detached;
            }
            _context.TblTransactions.Remove(transaction);
            return await SaveAsync();
        }

        public async Task<TblTransactions> GetTransactionAsync(int id)
        {
            return await _context.TblTransactions.FindAsync(id);
        }

        public async Task<ICollection<TblTransactions>> GetTransactionsAsync()
        {
            return await _context.TblTransactions.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> TransactionExistsAsync(int transactionId)
        {
            return await _context.TblTransactions.AnyAsync(t => t.Id == transactionId);
        }

        public async Task<bool> UpdateTransactionAsync(TblTransactions transaction)
        {
            _context.TblTransactions.Update(transaction);
            return await SaveAsync();
        }
    }
}
