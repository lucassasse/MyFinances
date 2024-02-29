using AutoMapper;
using MyFinances.Domain.Dtos;
using MyFinances.Domain.Models;
using MyFinances.Domain.ViewModels;

namespace MyFinances.Domain.Mappers
{
    public class FinancialTransactionMapper : Profile
    {
        public FinancialTransactionMapper() { 
            CreateMap<FinancialTransaction, FinancialTransactionViewModel>();

            CreateMap<FinancialTransaction, FinancialTransactionDetailsViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Bank.Name));

            CreateMap<FinancialTransactionCreateDto, FinancialTransaction>();
        }
    }
}
