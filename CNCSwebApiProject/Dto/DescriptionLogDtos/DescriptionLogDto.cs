using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.DescriptionLogDtos;

public class DescriptionLogDto
{
    public int? Id { get; set; }

    [Required]
    public string Details { get; set; } = null!;

    [Required]
    public  string Activity { get; set; } = null!;

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int ProductDescriptionId { get; set; }
}
