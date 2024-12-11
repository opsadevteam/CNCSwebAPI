using System;
using CNCSwebApiProject.Dto.DescriptionDtos;

namespace CNCSwebApiProject.Services.DescriptionService;

public interface IDescriptionService
{
    Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllAsync();
    Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllByProductIdAsync(int Product_Id);
    Task<DescriptionGetAndUpdateDto?> GetAsync(int id);
    Task<bool> AddAsync(ProductDescriptionCreateDto productDescriptionCreateDto); 
    Task<bool> UpdateDetailsAsync(int productDescription_Id, DescriptionGetAndUpdateDto descriptionGetAndUpdateDto); 
    Task<bool> DeleteAsync(int productDescription_Id);
}
