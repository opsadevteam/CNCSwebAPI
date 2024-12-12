using System;
using AutoMapper;
using CNCSwebApiProject.Dto.DescriptionDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.DescriptionService;

public class DescriptionService(IDescriptionRepository _productDescRepo, IMapper mapper) : IDescriptionService
{
    public async Task<bool> AddDescriptionAsync(ProductDescriptionCreateDto productDescriptionCreateDto)
    {
        return await _productDescRepo.AddDescriptionAsync(mapper.Map<ProductDescription>(productDescriptionCreateDto));
    }

    public async Task<bool> DeleteDescriptionAsync(int descriptionId)
    {
        return await _productDescRepo.DeleteDescriptionAsync(descriptionId);
    }

    public async Task<DescriptionDto?> GetDescriptionAsync(int descriptionId)
    {
         var obj = await _productDescRepo.GetDescriptionAsync(descriptionId);
        return mapper.Map<DescriptionDto?>(obj);
    }

    public async Task<IEnumerable<DescriptionDto>> GetDescriptionsAsync()
    {
                var obj =  await _productDescRepo.GetDescriptionsAsync();
        return mapper.Map<IEnumerable<DescriptionDto>>(obj);
    }

    public async Task<bool> IsDescriptionExists(int descriptionId, string description, int productId)
    {
        return await _productDescRepo.IsDescriptionExists(descriptionId, description, productId);
    }

    public async Task<bool> UpdateDescriptionAsync(int descriptionId, DescriptionDto descriptionDto)
    {
       var obj = await _productDescRepo.GetDescriptionAsync(descriptionId);
        if(obj is null) return false;
        if(string.IsNullOrWhiteSpace(descriptionDto.Description)) return false;

        obj.Description = descriptionDto.Description;

        return await _productDescRepo.UpdateDescriptionAsync(obj);
    }

}
