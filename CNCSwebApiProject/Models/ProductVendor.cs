using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Models;

public class ProductVendor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [MaxLength(50)]
    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public ICollection<ProductDescription> ProductDescription { get; set; } = [];

    public ICollection<ProductVendorLog> ProductVendorLog { get; set; } = [];
}
