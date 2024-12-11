using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Models;

public class ProductDescription
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public required string Description { get; set; }

    [MaxLength(50)]
    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public int ProductVendorId { get; set; }

    public ProductVendor ProductVendor { get; set; } = null!;

    public ICollection<ProductDescriptionLog> ProductDescriptionLog { get; set; } = [];

}
