using System;
using CNCSwebApiProject.Dto.ProductLogDtos;

namespace CNCSwebApiProject.Services.ProductLogService;

public interface IProductLogService
{
    Task<bool> AddProductLogAsync(ProductLogDto productLogDto);
}
