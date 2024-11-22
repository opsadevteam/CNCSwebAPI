using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Repository
{
    public class ProductVendorRepository : IProductVendor
    {
        private readonly CncssystemContext _context;

        public ProductVendorRepository(CncssystemContext context)
        {
            _context = context;
        }

        public bool CreateProductVendor(TblProductVendor productVendor)
        {
            _context.Add(productVendor);

            return Save();
        }

        public bool DeleteProductVendor(TblProductVendor productVendor)
        {
            _context.Remove(productVendor);

            return Save();
        }

        public TblProductVendor GetProductVendor(int id)
        {
            return _context.TblProductVendor.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<TblProductVendor> GetProductVendors()
        {
            return _context.TblProductVendor.ToList();
        }

        public bool ProductVendorExists(int productVendorId)
        {
            return _context.TblProductVendor.Any(p => p.Id == productVendorId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProductVendor(TblProductVendor productVendor)
        {
            _context.Update(productVendor);
            return Save();
        }
    }
}
