using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.DescriptionDtos;

public class ProductDescriptionCreateDto
{
    [Required]
    public required string Description { get; set; }

    [MaxLength(50)]
    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    [Required]
    public required int ProductVendorId { get; set; }
}
