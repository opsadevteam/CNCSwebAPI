using System;
using CNCSwebApiProject.Dto.ProductDtos;

namespace CNCSwebApiProject.Services.ProductService;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync(); 
    Task<ProductDto?> GetProductAsync(int productVendor_Id); 
    // Task<IEnumerable<ProductWithDescriptionDto>> GetAllProdWithDescAsync(); 
    // Task<ProductWithDescriptionDto?> GetProdWithDescAsync(int productVendor_Id); 
    Task<bool> AddAsync(ProductCreateDto productVendorCreateDto); 
    Task<bool> UpdateDetailsAsync(int productVendor_Id, ProductUpdateDto productVendorUpdateDto); 
    Task<bool> DeleteAsync(int productVendor_Id);
    Task<bool> IsNameExists(string Name, int productVendor_Id);

}
