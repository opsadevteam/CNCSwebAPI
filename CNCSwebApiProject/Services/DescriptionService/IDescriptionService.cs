using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.DescriptionService
{
    public interface IDescriptionService
    {
        Task<IEnumerable<DescriptionDto>> GetDescriptionsAsync();
        Task<DescriptionDto> GetDescriptionAsync(int id);
        Task<bool> CreateDescriptionAsync(DescriptionDto descriptionDto);
        Task<bool> DescriptionExistsAsync(int descriptionId);
        Task<bool> UpdateDescriptionAsync(DescriptionDto descriptionDto);
        Task<bool> DeleteDescriptionAsync(DescriptionDto descriptionDto);
        Task<bool> SaveAsync();
    }
}
