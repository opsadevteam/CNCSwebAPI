using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Dto.ProductVendorDtos;

public class ProductVendorNewDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<ProductDescriptionDto> ProductDescriptionDto { get; set; } = [];
}
