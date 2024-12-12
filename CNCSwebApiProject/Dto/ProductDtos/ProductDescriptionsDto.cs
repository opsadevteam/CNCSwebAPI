
using CNCSwebApiProject.Dto.DescriptionDtos;

namespace CNCSwebApiProject.Dto.ProductDtos;

public class ProductDescriptionsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<DescriptionDto?>? Descriptions {get; set;}
}
