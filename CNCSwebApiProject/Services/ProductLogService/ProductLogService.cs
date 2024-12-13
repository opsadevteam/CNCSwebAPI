using System;
using AutoMapper;
using CNCSwebApiProject.Dto.ProductLogDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.ProductLogService;

public class ProductLogService(IProductLogRepository _productLogRepository, IMapper mapper) : IProductLogService
{
    public async Task<bool> AddProductLogAsync(ProductLogDto productLogDto)
    {
        return await _productLogRepository.AddProductLogAsync(mapper.Map<ProductVendorLog>(productLogDto));
    }
}
