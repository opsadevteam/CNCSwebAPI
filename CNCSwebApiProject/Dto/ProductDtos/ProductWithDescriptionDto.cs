using System;
using CNCSwebApiProject.Dto.DescriptionDtos;

namespace CNCSwebApiProject.Dto.ProductDtos;

public class ProductWithDescriptionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<DescriptionGetAndUpdateDto> Descriptions { get; set; } = [];
}
