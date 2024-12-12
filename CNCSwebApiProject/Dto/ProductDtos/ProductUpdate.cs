using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.ProductDtos;

public class ProductUpdate
{
    [Required]
    public string Name { get; set; } = null!;

}
