using System;
using CNCSwebApiProject.Dto.ProductDtos;

namespace CNCSwebApiProject.Services.ProductService;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync(); 
    Task<ProductDto?> GetProductAsync(int productId); 
    Task<IEnumerable<ProductDescriptionsDto>> GetProductsDescriptionsAsync(); 
    Task<ProductDescriptionsDto?> GetProductDescriptionsAsync(int productId); 
    Task<bool> AddAProductsync(ProductCreateDto productVendorCreateDto); 
    Task<bool> UpdateProductAsync(int productId, string productName); 
    Task<bool> DeleteProductAsync(int productId);
    Task<bool> IsProductNameExists(string productName, int productId);

}
