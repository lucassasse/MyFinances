using AutoMapper;
using MyFinances.Domain.Models;
using MyFinances.Domain.ViewModels;

namespace MyFinances.Domain.Mappers
{
    public class FinancialTransactionMapper : Profile
    {
        public FinancialTransactionMapper() { 
            CreateMap<FinancialTransaction, FinancialTransactionViewModel>();
            //CreateMap<FinancialTransactionDto, FinancialTransaction>();
        }
    }
}
