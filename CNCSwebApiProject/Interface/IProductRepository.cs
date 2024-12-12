using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IProductRepository
{
        Task<IEnumerable<ProductVendor>> GetProductsAsync();
        Task<ProductVendor?> GetProductAsync(int productId);
        Task<IEnumerable<ProductVendor>> GetProductsDescriptionsAsync();
        Task<ProductVendor?> GetProductDescriptionsAsync(int productId);
        Task<bool> AddProductAsync(ProductVendor product);
        Task<bool> UpdateProductAsync(ProductVendor product);
        Task<bool> DeleteProductAsync(int productId);
        Task<bool> IsProductNameExists(string productName, int productId);
        Task<bool> SaveProductAsync();
}
