using System;

namespace CNCSwebApiProject.Dto.DescriptionDtos;

public class DescriptionGetAndUpdateDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public int ProductVendorId { get; set; }
}
