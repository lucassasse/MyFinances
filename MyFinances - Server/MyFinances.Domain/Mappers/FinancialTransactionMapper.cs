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

            CreateMap<Bank, FinancialTransactionDetailsViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<FinancialTransactionCreateDto, FinancialTransaction>();

            CreateMap<FinancialTransactionUpdateDto, FinancialTransaction>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.BankId, opt => opt.MapFrom(src => src.BankId));

            CreateMap<FinancialTransactionUpdateDto, FinancialTransaction>().ReverseMap();

        }
    }
}
