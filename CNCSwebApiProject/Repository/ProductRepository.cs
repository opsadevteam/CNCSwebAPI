using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository;

public class ProductRepository(CncssystemContext _context) : IProductRepository
{
    public async Task<int> AddProductAsync(ProductVendor product)
    {
        await _context.ProductVendor.AddAsync(product);
        var result = await SaveProductAsync();
        if (result) {
            var recentObj = await _context.ProductVendor.OrderByDescending(p => p.Id)
                                                        .FirstOrDefaultAsync();
            return recentObj?.Id ?? 0;
        }

        return 0;
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var deleted = await _context.ProductVendor
            .Where(a => a.Id == productId)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));

        if (deleted == 0) return false;

        var deleteDescriptions = await _context.ProductDescription
            .Where(a => a.ProductVendorId == productId)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));

        return deleted > 0;
    }

    public async Task<IEnumerable<ProductVendor>> GetProductsAsync()
    {
        return await _context.ProductVendor
        .Where(pv => pv.IsDeleted == false)
        .OrderByDescending(pv => pv.Id)
        .ToListAsync();
    }

    public async Task<IEnumerable<ProductVendor>> GetProductsDescriptionsAsync()
    {
        return await _context.ProductVendor
        .Where(pv => pv.IsDeleted == false)
        .OrderByDescending(pv => pv.Id)
        .Include(pv => pv.ProductDescription.Where(pd => pd.IsDeleted == false))
        .ToListAsync();
    }

    public async Task<ProductVendor?> GetProductAsync(int productId)
    {
        return await _context.ProductVendor
        .Where(a => a.Id == productId)
        .Where(a => a.IsDeleted == false)
        .SingleOrDefaultAsync();
    }

    public async Task<ProductVendor?> GetProductDescriptionsAsync(int productId)
    {
        return await _context.ProductVendor
        .Where(a => a.Id == productId)
        .Where(a => a.IsDeleted == false)
        .Include(pv => pv.ProductDescription.Where(pd => pd.IsDeleted == false))
        .SingleOrDefaultAsync();
    }

    public async Task<bool> IsProductNameExists(string productName, int productId)
    {
        return await _context.ProductVendor.AnyAsync(x => 
        x.Name!.ToLower().Trim() == productName.ToLower().Trim() && 
        x.Id != productId && x.IsDeleted == false);
    }

    public async Task<bool> SaveProductAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateProductAsync(ProductVendor product)
    {
        _context.Entry(product).State = EntityState.Modified;
        return await SaveProductAsync();
    }

    public async Task<ProductVendor?> GetProductWithLogsAsync(int productId)
    {
        return await _context.ProductVendor
            .Where(x => x.Id == productId)
            .Include(pv => pv.ProductVendorLog
                    .Where(pd => pd.ProductVendorId == productId)
                    .OrderByDescending(pd => pd.DateAdded))
            .SingleOrDefaultAsync();
    }
}