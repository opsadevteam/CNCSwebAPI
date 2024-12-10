using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.ProductVendorDtos;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using CNCSwebApiProject.Repository;

namespace CNCSwebApiProject.Services.ProductVendorService
{
    public class ProductVendorService : IProductVendorService
    {
        private readonly IProductVendorRepository _productVendorRepository;
        private readonly IMapper _mapper;

        public ProductVendorService(IProductVendorRepository productVendorRepository, IMapper mapper)
        {
            _productVendorRepository = productVendorRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductVendorAsync(ProductVendorDto productVendorDto)
        {
            var productVendorsAsync = await _productVendorRepository.GetProductVendorsAsync();
            var productVendors = productVendorsAsync
                .Where(c => c.ProductVendor.Trim().ToUpper() == productVendorDto.ProductVendor.Trim().ToUpper())
                .FirstOrDefault();
            if (productVendors != null) return false;
            var productVendor = _mapper.Map<TblProductVendor>(productVendorDto);
            return await _productVendorRepository.CreateProductVendorAsync(productVendor);
        }

        public async Task<bool> DeleteProductVendorAsync(ProductVendorDto productVendorDto)
        {
            var productVendor = _mapper.Map<TblProductVendor>(productVendorDto);
            return await _productVendorRepository.DeleteProductVendorAsync(productVendor);
        }

        public async Task<ProductVendorDto> GetProductVendorAsync(int id)
        {
            var productVendor = await _productVendorRepository.GetProductVendorAsync(id);
            if (productVendor == null) return null;
            return _mapper.Map<ProductVendorDto>(productVendor);
        }

        public async Task<IEnumerable<ProductVendorDto>> GetProductVendorsAsync()
        {
            var productVendors = await _productVendorRepository.GetProductVendorsAsync();
            return _mapper.Map<IEnumerable<ProductVendorDto>>(productVendors);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _productVendorRepository.SaveAsync();
            return result;
        }

        public async Task<bool> ProductVendorExistsAsync(int productvendorId)
        {
            return await _productVendorRepository.ProductVendorExistsAsync(productvendorId);
        }

        public async Task<bool> UpdateProductVendorAsync(ProductVendorDto productVendorDto)
        {
            var productVendor = _mapper.Map<TblProductVendor>(productVendorDto);
            return await _productVendorRepository.UpdateProductVendorAsync(productVendor);
        }

    }
}
