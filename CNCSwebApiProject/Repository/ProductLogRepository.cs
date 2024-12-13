using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Repository;

public class ProductLogRepository(CncssystemContext _context) : IProductLogRepository
{
    public async Task<bool> AddProductLogAsync(ProductVendorLog productVendorLog)
    {
        await _context.ProductVendorLog.AddAsync(productVendorLog);
        return await SaveProductLogAsync();
    }
    public async Task<bool> SaveProductLogAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
