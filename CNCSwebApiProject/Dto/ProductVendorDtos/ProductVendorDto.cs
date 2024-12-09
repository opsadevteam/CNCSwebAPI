using System;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Dto.ProductVendorDtos;

public class ProductVendorDto
{
    public int Id { get; set; }
    public int Name { get; set; }
    public ICollection<ProductDescriptionDto> ProductDescriptionDto { get; set; } = [];
}
