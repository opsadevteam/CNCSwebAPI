using System;
using AutoMapper;
using CNCSwebApiProject.Dto.ProductDescriptionDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.DescriptionService;

public class ProductDescriptionService(IProductDescriptionRepository _productDescRepo, IMapper mapper) : IProductDescriptionService
{
    public async Task<bool> AddAsync(ProductDescriptionCreateDto productDescriptionCreateDto)
    {
        return await _productDescRepo.AddAsync(mapper.Map<ProductDescription>(productDescriptionCreateDto));
    }

    public async Task<bool> DeleteAsync(int productDescription_Id)
    {
        return await _productDescRepo.DeleteAsync(productDescription_Id);
    }
    
    //abang lang po tong GetAsync
    public async Task<ProductDescriptionGetAndUpdateDto?> GetAsync(int id)
    {
        var obj = await _productDescRepo.GetAsync(id);
        return mapper.Map<ProductDescriptionGetAndUpdateDto?>(obj);
    }

    public async Task<bool> UpdateDetailsAsync(int productDescription_Id, ProductDescriptionGetAndUpdateDto productDescriptionGetAndUpdateDto)
    {
        var obj = await _productDescRepo.GetAsync(productDescription_Id);
        if(obj is null) return false;

        obj.Description = productDescriptionGetAndUpdateDto.Description;

        return await _productDescRepo.UpdateAsync(obj);
    }
}
