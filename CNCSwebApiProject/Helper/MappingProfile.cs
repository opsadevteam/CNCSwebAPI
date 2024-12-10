using AutoMapper;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Dto.ProductDescriptionDtos;
using CNCSwebApiProject.Dto.ProductVendorDtos;
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

            CreateMap<TblDescriptions, DescriptionDto>();
            CreateMap<DescriptionDto, TblDescriptions>();

            CreateMap<TblUserAccount, UserAccountListDto>();
            CreateMap<TblUserAccount, UserAccountGetAndUpdateDto>().ReverseMap();
            CreateMap<TblUserAccount, UserAccountCreateDto>().ReverseMap();

            CreateMap<TblActivityLog, ActivityLogGetDto>();
            CreateMap<TblActivityLog, ActivityLogInsertDto>().ReverseMap();

            CreateMap<ProductVendor, ProductVendorNewDto>()
            .ForMember(dest => dest.ProductDescriptionListDto, opt => opt.MapFrom(src => src.ProductDescription))
            .ReverseMap();

            CreateMap<ProductVendorCreateDto, ProductVendor>();
            CreateMap<ProductVendorUpdateDto, ProductVendor>();

            CreateMap<ProductDescription, ProductDescriptionGetAndUpdateDto>();
            CreateMap<ProductDescriptionCreateDto, ProductDescription>();

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
