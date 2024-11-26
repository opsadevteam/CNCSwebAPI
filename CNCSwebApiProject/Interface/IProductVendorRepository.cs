using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IProductVendorRepository
    {
        Task<ICollection<TblProductVendor>> GetProductVendorsAsync();
        Task<TblProductVendor> GetProductVendorAsync(int id);
        Task<bool> ProductVendorExistsAsync(int productVendorId);
        Task<bool> CreateProductVendorAsync(TblProductVendor productVendor);
        Task<bool> UpdateProductVendorAsync(TblProductVendor productVendor);
        Task<bool> DeleteProductVendorAsync(TblProductVendor productVendor);
        Task<bool> SaveAsync();
    }
}
