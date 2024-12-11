using System;
using AutoMapper;
using CNCSwebApiProject.Dto.ProductDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.Identity.Client;

namespace CNCSwebApiProject.Services.ProductService;

public class ProductService(IProductRepository _productRepository, IMapper mapper) : IProductService
{
    public async Task<bool> AddAsync(ProductCreateDto productVendorCreateDto)
    {
        return await _productRepository.AddAsync(mapper.Map<ProductVendor>(productVendorCreateDto));
    }

    public async Task<bool> DeleteAsync(int productVendor_Id)
    {
        return await _productRepository.DeleteAsync(productVendor_Id);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var obj = await _productRepository.GetProductsAsync();
        return mapper.Map<IEnumerable<ProductDto>>(obj);
    }

    // public async Task<IEnumerable<ProductWithDescriptionDto>> GetAllProdWithDescAsync()
    // {
    //     var obj = await _productRepository.GetAllProdWithDescAsync();
    //     return mapper.Map<IEnumerable<ProductWithDescriptionDto>>(obj);
    // }

    public async Task<ProductDto?> GetProductAsync(int productVendor_Id)
    {
        var obj = await _productRepository.GetProductAsync(productVendor_Id);
        return mapper.Map<ProductDto>(obj);
    }

    // public async Task<ProductWithDescriptionDto?> GetProdWithDescAsync(int productVendor_Id)
    // {
    //     var obj = await _productRepository.GetProdWithDescAsync(productVendor_Id);
    //     return mapper.Map<ProductWithDescriptionDto>(obj);
    // }

    public async Task<bool> IsNameExists(string Name, int productVendor_Id)
    {
        return await _productRepository.IsNameExists(Name, productVendor_Id);
    }

    public async Task<bool> UpdateDetailsAsync(int productVendor_Id, ProductUpdateDto productVendorUpdateDto)
    {
        var obj = await _productRepository.GetProductAsync(productVendor_Id);
        if(obj is null) return false;

        obj.Name = productVendorUpdateDto.Name;

        return await _productRepository.UpdateAsync(obj);   
    }
}
