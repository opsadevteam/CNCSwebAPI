using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.ProductVendorDtos;

public class ProductVendorUpdateDto
{
    [Required]
    public required string Name { get; set; }
}
