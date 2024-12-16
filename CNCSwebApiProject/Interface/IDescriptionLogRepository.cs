using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IDescriptionLogRepository
{
    Task<bool> AddDescriptionLogAsync(ProductDescriptionLog productDescriptionLog);

    Task<bool> SaveDescriptionLogAsync();
}
