using System;
using CNCSwebApiProject.Dto.ProductDescriptionDtos;

namespace CNCSwebApiProject.Services.DescriptionService;

public interface IProductDescriptionService
{
    Task<ProductDescriptionGetAndUpdateDto?> GetAsync(int id);
    Task<bool> AddAsync(ProductDescriptionCreateDto productDescriptionCreateDto); 
    Task<bool> UpdateDetailsAsync(int productDescription_Id, ProductDescriptionGetAndUpdateDto productDescriptionGetAndUpdateDto); 
    Task<bool> DeleteAsync(int productDescription_Id);
}
