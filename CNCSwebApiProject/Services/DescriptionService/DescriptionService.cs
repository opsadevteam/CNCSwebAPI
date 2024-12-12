using System;
using AutoMapper;
using CNCSwebApiProject.Dto.DescriptionDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.DescriptionService;

public class DescriptionService(IDescriptionRepository _productDescRepo, IMapper mapper) : IDescriptionService
{
    public async Task<bool> AddAsync(ProductDescriptionCreateDto productDescriptionCreateDto)
    {
        return await _productDescRepo.AddAsync(mapper.Map<ProductDescription>(productDescriptionCreateDto));
    }

    public async Task<bool> DeleteAsync(int productDescription_Id)
    {
        return await _productDescRepo.DeleteAsync(productDescription_Id);
    }

    public async Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllAsync()
    {
        var obj =  await _productDescRepo.GetAllAsync();
        return mapper.Map<IEnumerable<DescriptionGetAndUpdateDto>>(obj);
    }

    public async Task<IEnumerable<DescriptionGetAndUpdateDto>> GetAllByProductIdAsync(int Product_Id)
    {
        var obj =  await _productDescRepo.GetAllByProductIdAsync(Product_Id);
        return mapper.Map<IEnumerable<DescriptionGetAndUpdateDto>>(obj);
    }

    public async Task<DescriptionGetAndUpdateDto?> GetAsync(int id)
    {
        var obj = await _productDescRepo.GetAsync(id);
        return mapper.Map<DescriptionGetAndUpdateDto?>(obj);
    }

    public async Task<bool> IsDescriptionExists(int descriptionId, string name, int productId)
    {
        return await _productDescRepo.IsDescriptionExists(descriptionId, name, productId);
    }

    public async Task<bool> UpdateDetailsAsync(int productDescription_Id, DescriptionGetAndUpdateDto DescriptionGetAndUpdateDto)
    {
        var obj = await _productDescRepo.GetAsync(productDescription_Id);
        if(obj is null) return false;

        obj.Description = DescriptionGetAndUpdateDto.Description;

        return await _productDescRepo.UpdateAsync(obj);
    }


}
