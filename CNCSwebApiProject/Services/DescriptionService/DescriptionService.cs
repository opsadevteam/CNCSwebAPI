using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using CNCSwebApiProject.Repository;

namespace CNCSwebApiProject.Services.DescriptionService
{
    public class DescriptionService : IDescriptionService
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IMapper _mapper;

        public DescriptionService(IDescriptionRepository descriptionRepository,IMapper mapper)
        {
            _descriptionRepository = descriptionRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateDescriptionAsync(DescriptionDto descriptionDto)
        {
            var descriptionsAsync = await _descriptionRepository.GetDescriptionsAsync();
            var descriptions = descriptionsAsync
                .Where(c => c.Description.Trim().ToUpper() == descriptionDto.Description.Trim().ToUpper())
                .FirstOrDefault();
            if (descriptions != null) return false;
            var description = _mapper.Map<TblDescriptions>(descriptionDto);
            return await _descriptionRepository.CreateDescriptionAsync(description);
        }

        public async Task<bool> DeleteDescriptionAsync(DescriptionDto descriptionDto)
        {
            var description = _mapper.Map<TblDescriptions>(descriptionDto);
            return await _descriptionRepository.DeleteDescriptionAsync(description);
        }

        public async Task<bool> DescriptionExistsAsync(int descriptionId)
        {
            return await _descriptionRepository.DescriptionExistsAsync(descriptionId);
        }

        public async Task<DescriptionDto> GetDescriptionAsync(int id)
        {
            var description = await _descriptionRepository.GetDescriptionAsync(id);
            if (description == null) return null;
            return _mapper.Map<DescriptionDto>(description);
        }

        public async Task<IEnumerable<DescriptionDto>> GetDescriptionsAsync()
        {
            var descriptions = await _descriptionRepository.GetDescriptionsAsync();
            return _mapper.Map<IEnumerable<DescriptionDto>>(descriptions);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _descriptionRepository.SaveAsync();
            return result;
        }

        public async Task<bool> UpdateDescriptionAsync(DescriptionDto descriptionDto)
        {
            var description = _mapper.Map<TblDescriptions>(descriptionDto);
            return await _descriptionRepository.UpdateDescriptionAsync(description);
        }
    }
}
