using System;
using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.ActivityLogService;

public interface IActivityLogService
{
 Task<IEnumerable<ActivityLogGetDto>> GetAllAsync();
}
