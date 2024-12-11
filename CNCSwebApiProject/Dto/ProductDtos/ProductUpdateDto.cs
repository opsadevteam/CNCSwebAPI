using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.ProductDtos;

public class ProductUpdateDto
{
    [Required]
    public required string Name { get; set; }
}
