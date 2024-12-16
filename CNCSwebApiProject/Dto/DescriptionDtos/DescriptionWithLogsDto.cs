using System;
using CNCSwebApiProject.Dto.DescriptionLogDtos;

namespace CNCSwebApiProject.Dto.DescriptionDtos;

public class DescriptionWithLogsDto
{
   public int Id { get; set; }
    public string Description { get; set; } = null!;
    public IEnumerable<DescriptionLogDto?>? DescriptionLogs {get; set;}
}
