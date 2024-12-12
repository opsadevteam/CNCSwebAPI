using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository;

public class DescriptionRepository(CncssystemContext _context) : IDescriptionRepository
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

    public async Task<IEnumerable<ProductDescription>> GetAllAsync()
    {
        return await _context.ProductDescription
        .Where(a => a.IsDeleted == false)
        .OrderByDescending(pv => pv.Id)
        .Select(pd => new ProductDescription
        {
            Id = pd.Id,
            Description = pd.Description
        })
        .ToListAsync();
    }

    public async Task<IEnumerable<ProductDescription?>> GetAllByProductIdAsync(int Product_Id)
    {

        return await _context.ProductDescription
        .Where(a => a.ProductVendorId == Product_Id)
        .Where(a => a.IsDeleted == false)
        .OrderByDescending(pv => pv.Id)
        .Select(pd => new ProductDescription
        {
            Id = pd.Id,
            Description = pd.Description
        })
        .ToListAsync();
    }

    public async Task<ProductDescription?> GetAsync(int id)
    {
        return await _context.ProductDescription
        .Where(a => a.Id == id)
        .Where(a => a.IsDeleted == false)
        .Select(pd => new ProductDescription
        {
            Id = pd.Id,
            Description = pd.Description
        })
        .SingleOrDefaultAsync();
    }

    public async Task<bool> IsDescriptionExists(int descriptionId, string name, int productId)
    {
        return await _context.ProductDescription.AnyAsync(x => 
        x.Description!.ToLower().Trim() == name.ToLower().Trim() && 
        x.Id != descriptionId &&
        x.ProductVendorId == productId && 
        x.IsDeleted == false);
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
