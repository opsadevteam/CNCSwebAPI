using System;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository;

public class DescriptionLogRepository(CncssystemContext _context) : IDescriptionLogRepository
{
    public async Task<bool> AddDescriptionLogAsync(ProductDescriptionLog productDescriptionLog)
    {
        await _context.ProductDescriptionLog.AddAsync(productDescriptionLog);
        return await SaveDescriptionLogAsync();
    }

    public async Task<bool> SaveDescriptionLogAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
