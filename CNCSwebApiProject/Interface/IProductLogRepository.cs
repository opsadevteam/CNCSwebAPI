using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IProductLogRepository
{
    Task<bool> AddProductLogAsync(ProductVendorLog productVendorLog);

    Task<bool> SaveProductLogAsync();
}
