using System;
using AutoMapper;
using CNCSwebApiProject.Dto.ProductVendorDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.Identity.Client;

namespace CNCSwebApiProject.Services.ProductVendorService;

public class ProductVendorServiceNew(IProductVendorRepositoryNew _productRepository, IMapper mapper) : IProductVendorServiceNew
{
    public async Task<bool> AddAsync(ProductVendorCreateDto productVendorCreateDto)
    {
        return await _productRepository.AddAsync(mapper.Map<ProductVendor>(productVendorCreateDto));
    }

    public async Task<bool> DeleteAsync(int productVendor_Id)
    {
        return await _productRepository.DeleteAsync(productVendor_Id);
    }

    public async Task<IEnumerable<ProductVendorNewDto>> GetAllAsync()
    {
        var obj = await _productRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ProductVendorNewDto>>(obj);
    }

    public async Task<ProductVendorNewDto?> GetAsync(int id)
    {
        var obj = await _productRepository.GetAsync(id);
        return mapper.Map<ProductVendorNewDto>(obj);
    }

    public async Task<bool> IsNameExists(string Name, int productVendor_Id)
    {
        return await _productRepository.IsNameExists(Name, productVendor_Id);
    }

    public async Task<bool> UpdateDetailsAsync(int productVendor_Id, ProductVendorUpdateDto productVendorUpdateDto)
    {
        var obj = await _productRepository.GetAsync(productVendor_Id);
        if(obj is null) return false;

        obj.Name = productVendorUpdateDto.Name;

        return await _productRepository.UpdateAsync(obj);   
    }
}
