using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository
{
    public class ProductVendorRepository : IProductVendorRepository
    {
        private readonly CncssystemContext _context;

        public ProductVendorRepository(CncssystemContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProductVendorAsync(TblProductVendor productVendor)
        {
            await _context.TblProductVendor.AddAsync(productVendor);
            return await SaveAsync();
        }

        public async Task<bool> DeleteProductVendorAsync(TblProductVendor productVendor)
        {
            var existingProductVendor = await _context.TblProductVendor.FindAsync(productVendor.Id);
            if (existingProductVendor != null)
            {
                _context.Entry(existingProductVendor).State = EntityState.Detached;
            }
            _context.TblProductVendor.Remove(productVendor);
            return await SaveAsync();
        }

        public async Task<TblProductVendor> GetProductVendorAsync(int id)
        {
            return await _context.TblProductVendor.FindAsync(id);
        }

        public async Task<ICollection<TblProductVendor>> GetProductVendorsAsync()
        {
            return await _context.TblProductVendor.ToListAsync();
        }

        public async Task<bool> ProductVendorExistsAsync(int productVendorId)
        {
            return await _context.TblProductVendor.AnyAsync(t => t.Id == productVendorId);
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateProductVendorAsync(TblProductVendor productVendor)
        {
            _context.TblProductVendor.Update(productVendor);
            return await SaveAsync();
        }
    }
}
