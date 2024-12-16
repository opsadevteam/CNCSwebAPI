using System;

namespace CNCSwebApiProject.Dto.DescriptionLogDtos;

public class DescriptionLogDto
{
    public int Id { get; set; }

    public required string Details { get; set; }

    public required string Activity { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int ProductDescriptionId { get; set; }
}
