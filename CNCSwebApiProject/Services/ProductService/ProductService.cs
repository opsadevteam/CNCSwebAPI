using System;
using AutoMapper;
using CNCSwebApiProject.Dto.ProductDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.Identity.Client;

namespace CNCSwebApiProject.Services.ProductService;

public class ProductService(IProductRepository _productRepository, IMapper mapper) : IProductService
{
    public async Task<bool> AddAProductsync(ProductCreateDto productVendorCreateDto)
    {
        return await _productRepository.AddProductAsync(mapper.Map<ProductVendor>(productVendorCreateDto));
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        return await _productRepository.DeleteProductAsync(productId);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var obj = await _productRepository.GetProductsAsync();
        return mapper.Map<IEnumerable<ProductDto>>(obj);
    }

    public async Task<IEnumerable<ProductDescriptionsDto>> GetProductsDescriptionsAsync()
    {
        var obj = await _productRepository.GetProductsDescriptionsAsync();
        return mapper.Map<IEnumerable<ProductDescriptionsDto>>(obj);
    }

    public async Task<ProductDto?> GetProductAsync(int productId)
    {
        var obj = await _productRepository.GetProductAsync(productId);
        return mapper.Map<ProductDto>(obj);
    }

    public async Task<ProductDescriptionsDto?> GetProductDescriptionsAsync(int productId)
    {
        var obj = await _productRepository.GetProductDescriptionsAsync(productId);
        return mapper.Map<ProductDescriptionsDto>(obj);
    }

    public async Task<bool> IsProductNameExists(string productName, int productId)
    {
        return await _productRepository.IsProductNameExists(productName, productId);
    }

    public async Task<bool> UpdateProductAsync(int productId, string productName)
    {
        var obj = await _productRepository.GetProductAsync(productId);
        if(obj is null) return false;

        obj.Name = productName;

        return await _productRepository.UpdateProductAsync(obj);   
    }

    public async Task<IEnumerable<ProductWithLogsDto>> GetProductWithLogsAsync(int productId)
    {
        var obj = await _productRepository.GetProductWithLogsAsync(productId);
        return mapper.Map<IEnumerable<ProductWithLogsDto>>(obj);
    }
}
