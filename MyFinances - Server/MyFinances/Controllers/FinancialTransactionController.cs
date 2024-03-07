using Microsoft.AspNetCore.Mvc;
using MyFinances.Domain.Dtos;
using MyFinances.Domain.Models;
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

        //To list all items on the Dashboard screen.
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

        //To display details when clicking a list item on the Dashboard screen.
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Invalid ID");

                var financialTransaction = _financialTransactionService.GetById(id);
                if (financialTransaction == null)
                    return NotFound("Financial Transaction not found.");

                return Ok(financialTransaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error in GetById Controller. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FinancialTransactionCreateDto financialTransaction)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model state");

                var createdFinancialTransaction = _financialTransactionService.Create(financialTransaction);

                var resourceUri = Url.Action("Get", new {id = createdFinancialTransaction.Id });

                return Created(resourceUri, createdFinancialTransaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error in Create Controller. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] FinancialTransactionUpdateDto financialTransaction, [FromRoute] int id)
        {
            try
            {
                if (_financialTransactionService.GetById(id) == null) return NotFound("Financial Transaction not found");

                _financialTransactionService.Update(financialTransaction, id);
                return Ok();
            }
            catch(Exception ex) {
                return StatusCode(500, $"Internal Server Error in update Controller. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var existingFinancialTransaction = _financialTransactionService.GetById(id);

                if (existingFinancialTransaction == null) return NotFound("Financial Transaction not found");

                _financialTransactionService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error in delete Controller. Error: {ex.Message}");
            }
        }
    }
}
