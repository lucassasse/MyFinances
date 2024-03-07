using MyFinances.Domain.Dtos;
using MyFinances.Domain.Models;

namespace MyFinances.Repository.Interfaces
{
    public interface IFinancialTransactionRepository

    {
        List<FinancialTransaction> GetAll();
        FinancialTransaction GetById(int id);
        FinancialTransaction Create(FinancialTransaction model);
        FinancialTransaction Update(FinancialTransaction model);
        FinancialTransaction Delete(FinancialTransaction model);
    }
}
