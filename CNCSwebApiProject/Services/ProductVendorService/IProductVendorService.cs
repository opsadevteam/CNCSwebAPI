using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.ProductVendorService
{
    public interface IProductVendorService
    {
        Task<IEnumerable<ProductVendorDto>> GetProductVendorsAsync();
        Task<ProductVendorDto> GetProductVendorAsync(int id);
        Task<bool> CreateProductVendorAsync(ProductVendorDto productVendorDto);
        Task<bool> ProductVendorExistsAsync(int productvendorId);
        Task<bool> UpdateProductVendorAsync(ProductVendorDto productVendorDto);
        Task<bool> DeleteProductVendorAsync(ProductVendorDto productVendorDto);
        Task<bool> SaveAsync();
    }
}
