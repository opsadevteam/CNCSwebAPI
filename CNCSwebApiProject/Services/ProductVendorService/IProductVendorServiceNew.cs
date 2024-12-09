using System;
using CNCSwebApiProject.Dto.ProductVendorDtos;

namespace CNCSwebApiProject.Services.ProductVendorService;

public interface IProductVendorServiceNew
{
    Task<IEnumerable<ProductVendorDto>> GetAllAsync(); //get all user account
    Task<ProductVendorDto?> GetAsync(int id); //get single user account
    Task<bool> AddAsync(ProductVendorDto productVendorDto); // Add new user account
    Task<bool> UpdateDetailsAsync(int productVendor_Id, ProductVendorDto productVendorDto); // Update existing user account
    Task<bool> DeleteAsync(int productVendor_Id); // Delete user account by ID

}
