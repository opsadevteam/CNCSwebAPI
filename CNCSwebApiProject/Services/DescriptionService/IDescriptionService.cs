using System;
using CNCSwebApiProject.Dto.DescriptionDtos;

namespace CNCSwebApiProject.Services.DescriptionService;

public interface IDescriptionService
{
    Task<IEnumerable<DescriptionDto>> GetDescriptionsAsync();
    // Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllByProductIdAsync(int productId);
    Task<DescriptionDto?> GetDescriptionAsync(int descriptionId);
    Task<bool> IsDescriptionExists(int descriptionId, string description, int productId);
    Task<bool> AddDescriptionAsync(ProductDescriptionCreateDto descriptionCreateDto); 
    Task<bool> UpdateDescriptionAsync(int descriptionId, DescriptionDto descriptionDto); 
    Task<bool> DeleteDescriptionAsync(int descriptionId);
}
