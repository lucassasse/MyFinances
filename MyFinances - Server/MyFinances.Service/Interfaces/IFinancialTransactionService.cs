using MyFinances.Domain.Models;
using MyFinances.Domain.ViewModels;

namespace MyFinances.Service.Interfaces
{
    public interface IFinancialTransactionService
    {
        List<FinancialTransactionViewModel> GetAll();
    }
}
