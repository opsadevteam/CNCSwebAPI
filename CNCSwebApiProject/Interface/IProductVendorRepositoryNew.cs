using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IProductVendorRepositoryNew
{
        Task<IEnumerable<ProductVendor>> GetAllAsync();
        Task<ProductVendor?> GetAsync(int id);
        Task<bool> AddAsync(ProductVendor productVendor);
        Task<bool> UpdateAsync(ProductVendor productVendor);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
}
