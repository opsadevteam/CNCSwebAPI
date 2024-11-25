using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<TblTransactions, TransactionDto>();
            CreateMap<TransactionDto, TblTransactions>();

            CreateMap<TblProductVendor, ProductVendorDto>();
            CreateMap<ProductVendorDto, TblProductVendor>();

            CreateMap<TblDescriptions, DescriptionDto>();
            CreateMap<DescriptionDto, TblDescriptions>();

            CreateMap<TblUserAccount, UserAccountDto>();
            CreateMap<UserAccountDto, TblUserAccount>();
        }
    }
}
