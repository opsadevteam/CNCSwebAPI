using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IProductRepository
{
        Task<IEnumerable<ProductVendor>> GetProductsAsync();
        Task<ProductVendor?> GetProductAsync(int id);
        // Task<IEnumerable<ProductVendor>> GetAllProdWithDescAsync();
        // Task<ProductVendor?> GetProdWithDescAsync(int id);
        Task<bool> AddAsync(ProductVendor productVendor);
        Task<bool> UpdateAsync(ProductVendor productVendor);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsNameExists(string Name, int id);
        Task<bool> SaveAsync();
}
