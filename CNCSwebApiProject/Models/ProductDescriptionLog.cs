using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Models;

public class ProductDescriptionLog
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

    public int ProductDescriptionId { get; set; }
    
    public ProductDescription ProductDescription { get; set; } = null!;
}
