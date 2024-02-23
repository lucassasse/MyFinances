using AutoMapper;
using MyFinances.Service.Interfaces;
using MyFinances.Repository.Interfaces;
using MyFinances.Domain.ViewModels;

namespace MyFinances.Service.Services
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;
        private readonly IMapper _mapper;

        public FinancialTransactionService(IFinancialTransactionRepository financialTransactionRepository, IMapper mapper)
        {
            _financialTransactionRepository = financialTransactionRepository;
            _mapper = mapper;
        }

        public List<FinancialTransactionViewModel> GetAll()
        {
            try
            {
                var transaction = _financialTransactionRepository.GetAll();
                var financialTransactionViewModel = _mapper.Map<List<FinancialTransactionViewModel>>(transaction);
                return financialTransactionViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting all financial transaction.", ex);
            }
        }
    }
}
