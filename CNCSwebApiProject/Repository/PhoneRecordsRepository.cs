﻿using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository
{
    public class PhoneRecordsRepository : IPhoneRecordsRepository
    {
        private readonly CncssystemContext _context;

        public PhoneRecordsRepository(CncssystemContext context)
        {
            _context = context;
        }
        public async Task<ICollection<TblTransactions>> GetPhoneRecordsTableAsync()
        {
            return await _context.TblTransactions
                                  .Include(t => t.ProductVendor)
                                  .Include(t => t.Description)
                                  .ToListAsync();
        }

        public async Task<TblTransactions> GetTransactionAsync(int id)
        {
            return await _context.TblTransactions
                                  .Where(e => e.Id == id)
                                  .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> SoftDeleteAsync(int id, bool? isDeleted)
        {
            var existingTransaction = await _context.TblTransactions.FindAsync(id);
            if (existingTransaction == null)
                return false;

            existingTransaction.IsDeleted = isDeleted;
            _context.TblTransactions.Update(existingTransaction);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> TransactionExistsAsync(int transactionId)
        {
            return await _context.TblTransactions.AnyAsync(p => p.Id == transactionId);
        }
    }
}