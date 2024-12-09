using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Models;

public class ProductVendorLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Details { get; set; }

    [Required]
    [MaxLength(10)]
    public required string Activity { get; set; }

    [MaxLength(50)]
    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int ProductVendorId { get; set; }

    public ProductVendor ProductVendor { get; set; } = null!;
}
