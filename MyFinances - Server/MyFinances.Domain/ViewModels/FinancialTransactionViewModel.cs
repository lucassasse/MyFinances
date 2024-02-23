using System.ComponentModel.DataAnnotations;

namespace MyFinances.Domain.ViewModels
{
    public class FinancialTransactionViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
