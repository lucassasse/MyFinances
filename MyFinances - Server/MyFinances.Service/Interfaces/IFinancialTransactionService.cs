using MyFinances.Domain.Dtos;
using MyFinances.Domain.Models;
using MyFinances.Domain.ViewModels;

namespace MyFinances.Service.Interfaces
{
    public interface IFinancialTransactionService
    {
        List<FinancialTransactionViewModel> GetAll();
        FinancialTransactionDetailsViewModel GetById(int id);
        FinancialTransaction Create(FinancialTransactionCreateDto DtoModel);
    }
}
