using System;
using AutoMapper;
using CNCSapi.Interface;
using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.ActivityLogService;

public class ActivityLogService(IActivityLogRepository _activityLogRepository, IMapper mapper) : IActivityLogService
{
    public async Task<IEnumerable<ActivityLogGetDto>> GetAllAsync()
    {
        var obj =  await _activityLogRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ActivityLogGetDto>>(obj);
    }
}
