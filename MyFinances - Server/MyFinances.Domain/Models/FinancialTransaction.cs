using MyFinances.Domain.Enums;

namespace MyFinances.Domain.Models
{
    public class FinancialTransaction : BaseEntity
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public ExpenseType Type { get; set; }
        public DateTime Date { get; set; }
        public bool WithdrawalOrDeposit { get; set; } //0 = input | 1 = output

        public int BankId { get; set; }
        //[JsonIgnore]
        public virtual Bank Bank { get; set; }
    }
}
