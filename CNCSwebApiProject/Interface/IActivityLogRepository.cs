using System;
using CNCSwebApiProject.Models;

namespace CNCSapi.Interface;

public interface IActivityLogRepository
{
    Task<IEnumerable<TblActivityLog>> GetAllAsync();
}
