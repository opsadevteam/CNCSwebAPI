using System;
using AutoMapper;
using CNCSwebApiProject.Dto.DescriptionLogDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.DescriptionLogService;

public class DescriptionLogService(IDescriptionLogRepository _descLogRepo, IMapper mapper) : IDescriptionLogService
{
    public async Task<bool> AddDescriptionLogAsync(DescriptionLogDto descriptionLogDto)
    {
        return await _descLogRepo.AddDescriptionLogAsync(mapper.Map<ProductDescriptionLog>(descriptionLogDto));
    }
}
