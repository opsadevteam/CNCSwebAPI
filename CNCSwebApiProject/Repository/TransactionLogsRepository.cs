using AutoMapper;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository
{
    public class TransactionLogsRepository : ITransactionLogsRepository
    {
        private readonly CncssystemContext _context;
        private readonly IMapper _mapper;

        public TransactionLogsRepository(CncssystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        public async Task<ICollection<TblTransactionLogs>> GetLogsbyTransactionIdAsync(string transactionId)
        {
            return await _context.TblTransactionLogs
                                 .Include(t => t.ProductVendor)
                                 .Include(t => t.Description)
                                 .Where(t => t.TransactionId == transactionId) 
                                 .ToListAsync(); 
        }


        public async Task<ICollection<TblTransactionLogs>> GetTransactionLogsAsync()
        {
            return await _context.TblTransactionLogs
                                  .Include(t => t.ProductVendor)
                                  .Include(t => t.Description)
                                  .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> TransactionLogsExistsAsync(int transactionId)
        {
            return await _context.TblTransactions.AnyAsync(p => p.Id == transactionId);
        }
    }
}
