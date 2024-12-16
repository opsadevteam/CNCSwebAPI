using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository;

public class DescriptionRepository(CncssystemContext _context) : IDescriptionRepository
{
   public async Task<bool> AddDescriptionAsync(ProductDescription productDescription)
    {
        await _context.ProductDescription.AddAsync(productDescription);
        return await SaveDescriptionAsync();
    }

   public async Task<bool> DeleteDescriptionAsync(int descriptionId)
    {
        var deleted = await _context.ProductDescription
        .Where(a => a.Id == descriptionId)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));

        return deleted > 0;
    }

    public async Task<IEnumerable<ProductDescription>> GetDescriptionsAsync()
    {
        return await _context.ProductDescription
        .Where(a => a.IsDeleted == false)
        .OrderByDescending(pv => pv.Id)
        .ToListAsync();
    }

    // public async Task<IEnumerable<ProductDescription?>> GetAllByProductIdAsync(int Product_Id)
    // {

    //     return await _context.ProductDescription
    //     .Where(a => a.ProductVendorId == Product_Id)
    //     .Where(a => a.IsDeleted == false)
    //     .OrderByDescending(pv => pv.Id)
    //     .Select(pd => new ProductDescription
    //     {
    //         Id = pd.Id,
    //         Description = pd.Description
    //     })
    //     .ToListAsync();
    // }

    public async Task<ProductDescription?> GetDescriptionAsync(int descriptionId)
    {
        return await _context.ProductDescription
        .Where(a => a.Id == descriptionId)
        .Where(a => a.IsDeleted == false)
        .SingleOrDefaultAsync();
    }

    public async Task<bool> IsDescriptionExists(int descriptionId, string description, int productId)
    {
        return await _context.ProductDescription.AnyAsync(x => 
        x.Description!.ToLower().Trim() == description.ToLower().Trim() && 
        x.Id != descriptionId &&
        x.ProductVendorId == productId && 
        x.IsDeleted == false);
    }

    public async Task<bool> SaveDescriptionAsync()
    {
       return await _context.SaveChangesAsync() > 0;
    }

   public async Task<bool> UpdateDescriptionAsync(ProductDescription productDescription)
    {
        _context.Entry(productDescription).State = EntityState.Modified;
        return await SaveDescriptionAsync();
    }

    public async Task<ProductDescription?> GetDescriptionWithLogs(int descriptionId)
    {
        return await _context.ProductDescription
        .Where(x => x.Id == descriptionId)
        .Include(pd => pd.ProductDescriptionLog.Where(pv => pv.ProductDescriptionId == descriptionId))
        .SingleOrDefaultAsync();
    }
}
