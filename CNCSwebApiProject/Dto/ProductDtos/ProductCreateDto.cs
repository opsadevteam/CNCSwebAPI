using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.ProductDtos;

public class ProductCreateDto
{
    [Required]
    public required string Name { get; set; }
    public string? AddedBy { get; set; }
    public DateTime? DateAdded { get; set; }
    public bool? IsDeleted { get; set; }
}
