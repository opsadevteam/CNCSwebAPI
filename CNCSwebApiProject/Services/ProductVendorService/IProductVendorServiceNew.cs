using System;
using CNCSwebApiProject.Dto.ProductVendorDtos;

namespace CNCSwebApiProject.Services.ProductVendorService;

public interface IProductVendorServiceNew
{
    Task<IEnumerable<ProductVendorNewDto>> GetAllAsync(); 
    Task<ProductVendorNewDto?> GetAsync(int productVendor_Id); 
    Task<bool> AddAsync(ProductVendorCreateDto productVendorCreateDto); 
    Task<bool> UpdateDetailsAsync(int productVendor_Id, ProductVendorUpdateDto productVendorUpdateDto); 
    Task<bool> DeleteAsync(int productVendor_Id);
    Task<bool> IsNameExists(string Name, int productVendor_Id);

}
