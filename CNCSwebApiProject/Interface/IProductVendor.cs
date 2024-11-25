using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IProductVendor
    {
        ICollection<TblProductVendor> GetProductVendors();
        TblProductVendor GetProductVendor(int id);
        bool ProductVendorExists(int productVendorId);
        bool CreateProductVendor(TblProductVendor productVendor);
        bool UpdateProductVendor(TblProductVendor productVendor);
        bool DeleteProductVendor(TblProductVendor productVendor);
        bool Save();
    }
}
