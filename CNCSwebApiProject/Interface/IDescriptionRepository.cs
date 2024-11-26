using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IDescriptionRepository
    {
        Task<ICollection<TblDescriptions>> GetDescriptionsAsync();
        Task<TblDescriptions> GetDescriptionAsync(int id);
        Task<bool> DescriptionExistsAsync(int descriptionId);
        Task<bool> CreateDescriptionAsync(TblDescriptions description);
        Task<bool> UpdateDescriptionAsync(TblDescriptions description);
        Task<bool> DeleteDescriptionAsync(TblDescriptions description);
        Task<bool> SaveAsync();
    }
}
