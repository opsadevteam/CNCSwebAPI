using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IDescriptionRepository
{
        Task<IEnumerable<ProductDescription>> GetDescriptionsAsync(); 
        // Task<IEnumerable<ProductDescription?>> GetAllByProductIdAsync(int productId); 
        Task<ProductDescription?> GetDescriptionWithLogs(int descriptionId);
        Task<ProductDescription?> GetDescriptionAsync(int descriptionId); 
        Task<bool> IsDescriptionExists(int descriptionId, string description, int productId); 
        Task<bool> AddDescriptionAsync(ProductDescription productDescription);
        Task<bool> UpdateDescriptionAsync(ProductDescription productDescription);
        Task<bool> DeleteDescriptionAsync(int descriptionId);
        Task<bool> SaveDescriptionAsync();
}
