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


        }
    }
}
