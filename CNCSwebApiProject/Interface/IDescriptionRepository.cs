using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface;

public interface IDescriptionRepository
{
        Task<IEnumerable<ProductDescription>> GetAllAsync(); 
        Task<IEnumerable<ProductDescription>> GetAllByProductIdAsync(int Product_Id); 
        Task<ProductDescription?> GetAsync(int id); 
        Task<bool> AddAsync(ProductDescription productDescription);
        Task<bool> UpdateAsync(ProductDescription productDescription);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
}
