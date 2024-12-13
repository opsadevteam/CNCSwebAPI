using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.DescriptionDtos;
using CNCSwebApiProject.Dto.ProductDtos;
using CNCSwebApiProject.Dto.ProductLogDtos;
using CNCSwebApiProject.Dto.UserAccountsDtos;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<TblTransactions, TransactionDto>();
            CreateMap<TransactionDto, TblTransactions>();

            CreateMap<TblTransactions, TransactionDetaildDto>();
            CreateMap<TransactionDetaildDto, TblTransactions>();

            CreateMap<TblProductVendor, ProductVendorDto>();
            CreateMap<ProductVendorDto, TblProductVendor>();

            CreateMap<TblUserAccount, UserAccountListDto>();
            CreateMap<TblUserAccount, UserAccountGetAndUpdateDto>().ReverseMap();
            CreateMap<TblUserAccount, UserAccountCreateDto>().ReverseMap();

            CreateMap<TblActivityLog, ActivityLogGetDto>();
            CreateMap<TblActivityLog, ActivityLogInsertDto>().ReverseMap();

            CreateMap<ProductVendor, ProductDto>();
            CreateMap<ProductVendor, ProductDescriptionsDto>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.ProductDescription))
            .ReverseMap();
            CreateMap<ProductVendor, ProductWithLogsDto>()
            .ForMember(dest => dest.ProductLogs, opt => opt.MapFrom(src => src.ProductVendorLog))
            .ReverseMap();
            CreateMap<ProductCreateDto, ProductVendor>();

            CreateMap<ProductDescription, DescriptionDto>();
            CreateMap<ProductDescriptionCreateDto, ProductDescription>();

            CreateMap<ProductLogDto, ProductVendorLog>().ReverseMap();

            // Mapping for TblTransactions to TransactionDto
            CreateMap<TblTransactions, EmailRecordsDto>()
                .ForMember(dest => dest.ProductVendorId,
                           opt => opt.MapFrom(src => src.ProductVendor != null ? src.ProductVendor.ProductVendor : "Unknown"))
                .ForMember(dest => dest.DescriptionId,
                           opt => opt.MapFrom(src => src.Description != null ? src.Description.Description : "No Description"))
                .ReverseMap();

            // Custom mapping for PhoneRecordsDto
            CreateMap<TblTransactions, PhoneRecordsDto>()
                .ForMember(dest => dest.ProductVendorId,
                           opt => opt.MapFrom(src => src.ProductVendor != null ? src.ProductVendor.ProductVendor : "Unknown"))
                .ForMember(dest => dest.DescriptionId,
                           opt => opt.MapFrom(src => src.Description != null ? src.Description.Description : "No Description"))
                .ReverseMap();

            // Custom mapping for TransactionLogsDto
            CreateMap<TblTransactionLogs, TransactionLogsDto>()
                .ForMember(dest => dest.ProductVendorId,
                           opt => opt.MapFrom(src => src.ProductVendor != null ? src.ProductVendor.ProductVendor : "Unknown"))
                .ForMember(dest => dest.DescriptionId,
                           opt => opt.MapFrom(src => src.Description != null ? src.Description.Description : "No Description"))
                .ReverseMap();


        }
    
    }
}
