using MyFinances.Domain.Data;
using MyFinances.Domain.Models;
using MyFinances.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyFinances.Repository.Repositorys
{
    public class FinancialTransactionRepository : BaseRepository, IFinancialTransactionRepository
    {
        public FinancialTransactionRepository(AppDbContext context) : base(context)
        {
        }

        public List<FinancialTransaction> GetAll()
        {
            return _context.FinancialTransaction.ToList();
        }
    }
}
