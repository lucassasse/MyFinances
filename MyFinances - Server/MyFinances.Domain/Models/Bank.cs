using System.Text.Json.Serialization;

namespace MyFinances.Domain.Models 
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        [JsonIgnore]
        public virtual List<FinancialTransaction> FinancialTransaction {  get; set; }
    }
}
