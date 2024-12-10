using System;

namespace CNCSwebApiProject.Dto.ProductDescriptionDtos;

public class ProductDescriptionGetAndUpdateDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}
