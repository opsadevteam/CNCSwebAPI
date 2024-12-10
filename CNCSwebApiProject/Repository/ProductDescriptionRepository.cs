using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository;

public class ProductDescriptionRepository(CncssystemContext _context) : IProductDescriptionRepository
{
   public async Task<bool> AddAsync(ProductDescription productDescription)
    {
        await _context.ProductDescription.AddAsync(productDescription);
        return await SaveAsync();
    }

   public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _context.ProductDescription
        .Where(a => a.Id == id)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));

        return deleted > 0;
    }

    public async Task<ProductDescription?> GetAsync(int id)
    {
        return await _context.ProductDescription
        .Where(a => a.Id == id)
        .Where(a => a.IsDeleted == false)
        .SingleOrDefaultAsync();
    }

    public async Task<bool> SaveAsync()
    {
       return await _context.SaveChangesAsync() > 0;
    }

   public async Task<bool> UpdateAsync(ProductDescription productDescription)
    {
        _context.Entry(productDescription).State = EntityState.Modified;
        return await SaveAsync();
    }
}
