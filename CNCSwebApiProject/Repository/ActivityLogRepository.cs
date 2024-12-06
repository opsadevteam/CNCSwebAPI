using System;
using CNCSapi.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSapi.Repository;

public class ActivityLogRepository(CncssystemContext context) : IActivityLogRepository
{
    public async Task<IEnumerable<TblActivityLog>> GetAllAsync()
    {
        return await context.TblActivityLog
            .OrderByDescending( x => x.Id)
            .ToListAsync();
    }
}
