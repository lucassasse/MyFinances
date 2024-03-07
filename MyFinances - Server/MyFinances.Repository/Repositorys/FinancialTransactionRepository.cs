using MyFinances.Domain.Data;
using MyFinances.Domain.Models;
using MyFinances.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.Dtos;

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

        public FinancialTransaction GetById(int id) {
            return _context.FinancialTransaction
                .Include(x => x.Bank)
                .FirstOrDefault(e => e.Id == id);
        }
        
        public FinancialTransaction Create(FinancialTransaction financialTransaction)
        {
            _context.Add(financialTransaction);

            _context.SaveChanges();

            return financialTransaction;
        }

        public FinancialTransaction Update(FinancialTransaction financialTransaction)
        {
            _context.Update(financialTransaction);

            _context.SaveChanges();

            return financialTransaction;
        }

        public FinancialTransaction Delete(FinancialTransaction financialTransaction)
        {
            _context.Remove(financialTransaction);

            _context.SaveChanges();

            return financialTransaction;
        }
    }
}
