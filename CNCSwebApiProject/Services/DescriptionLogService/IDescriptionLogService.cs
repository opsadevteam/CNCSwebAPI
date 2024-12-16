using System;
using CNCSwebApiProject.Dto.DescriptionLogDtos;

namespace CNCSwebApiProject.Services.DescriptionLogService;

public interface IDescriptionLogService
{
 Task<bool> AddDescriptionLogAsync(DescriptionLogDto descriptionLogDto);
}
