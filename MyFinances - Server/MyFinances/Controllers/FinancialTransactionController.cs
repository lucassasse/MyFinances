using Microsoft.AspNetCore.Mvc;
using MyFinances.Domain.ViewModels;
using MyFinances.Service.Interfaces;

namespace MyFinances.Controllers
{
    [Route("/api/[controller]")]
    public class FinancialTransactionController : Controller
    {
        private readonly IFinancialTransactionService _financialTransactionService;

        public FinancialTransactionController(IFinancialTransactionService financialTransactionService)
        {
            _financialTransactionService = financialTransactionService;
        }

        [HttpGet]
        public ActionResult<List<FinancialTransactionViewModel>> GetAll()
        {
            try
            {
                var financialTransaction = _financialTransactionService.GetAll();
                return Ok(financialTransaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
