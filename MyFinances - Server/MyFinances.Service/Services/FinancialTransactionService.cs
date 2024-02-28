using AutoMapper;
using MyFinances.Service.Interfaces;
using MyFinances.Repository.Interfaces;
using MyFinances.Domain.ViewModels;
using MyFinances.Domain.Dtos;
using MyFinances.Domain.Models;

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

        public FinancialTransactionDetailsViewModel GetById(int id)
        {
            try
            {
                var financialTransaction = _financialTransactionRepository.GetById(id);

                var financialTransactionDetailsViewModel = _mapper.Map<FinancialTransactionDetailsViewModel>(financialTransaction);

                return financialTransactionDetailsViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching the financial transaction.", ex);
            }
        }

        public FinancialTransaction Create(FinancialTransactionCreateDto model)
        {
            try
            {
                var financialTransaction = _mapper.Map<FinancialTransaction>(model);

                return _financialTransactionRepository.Create(financialTransaction);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Error occurred while creating financial transaction.", ex);
            }
        }
    }
}
