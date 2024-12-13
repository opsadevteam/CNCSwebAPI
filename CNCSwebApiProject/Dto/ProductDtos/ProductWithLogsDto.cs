using System;
using CNCSwebApiProject.Dto.ProductLogDtos;

namespace CNCSwebApiProject.Dto.ProductDtos;

public class ProductWithLogsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<ProductLogDto?>? ProductLogs {get; set;}
}
