using System;
using CNCSwebApiProject.Dto.DescriptionDtos;

namespace CNCSwebApiProject.Services.DescriptionService;

public interface IDescriptionService
{
    Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllAsync();
    Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllByProductIdAsync(int productId);
    Task<DescriptionGetAndUpdateDto?> GetAsync(int id);
    Task<bool> IsDescriptionExists(int descriptionId, string name, int productId);
    Task<bool> AddAsync(ProductDescriptionCreateDto descriptionCreateDto); 
    Task<bool> UpdateDetailsAsync(int descriptionId, DescriptionGetAndUpdateDto descriptionGetAndUpdateDto); 
    Task<bool> DeleteAsync(int descriptionId);
}
