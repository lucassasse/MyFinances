using MyFinances.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyFinances.Domain.ViewModels
{
    public class FinancialTransactionDetailsViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public ExpenseType Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool WithdrawalOrDeposit { get; set; } //0 = input | 1 = output
        [Required]
        public int BankId { get; set; }
    }
}