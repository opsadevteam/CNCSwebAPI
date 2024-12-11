using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository;

public class ProductRepository(CncssystemContext _context) : IProductRepository
{
    public async Task<bool> AddAsync(ProductVendor productVendor)
    {
        await _context.ProductVendor.AddAsync(productVendor);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _context.ProductVendor
        .Where(a => a.Id == id)
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

    // public async Task<IEnumerable<ProductVendor>> GetAllProdWithDescAsync()
    // {
    //     return await _context.ProductVendor
    //     .Where(pv => pv.IsDeleted == false)
    //     .OrderByDescending(pv => pv.Id)
    //     .Include(pv => pv.ProductDescription)
    //     .ToListAsync();
    // }

    public async Task<ProductVendor?> GetProductAsync(int id)
    {
        return await _context.ProductVendor
        .Where(a => a.Id == id)
        .Where(a => a.IsDeleted == false)
        .SingleOrDefaultAsync();
    }

    // public async Task<ProductVendor?> GetProdWithDescAsync(int id)
    // {
    //     return await _context.ProductVendor
    //     .Where(a => a.Id == id)
    //     .Where(a => a.IsDeleted == false)
    //     .Include(pv => pv.ProductDescription)
    //     .SingleOrDefaultAsync();
    // }

    public async Task<bool> IsNameExists(string Name, int id)
    {
        return await _context.ProductVendor.AnyAsync(x => x.Name!.ToLower() == Name.ToLower() && x.Id != id && x.IsDeleted == false);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(ProductVendor productVendor)
    {
        _context.Entry(productVendor).State = EntityState.Modified;
        return await SaveAsync();
    }
}
