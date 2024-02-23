using MyFinances.Domain.Models;

namespace MyFinances.Repository.Interfaces
{
    public interface IFinancialTransactionRepository

    {
        List<FinancialTransaction> GetAll();
    }
}
