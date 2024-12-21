using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class TransactionPlanViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsWithdrawl { get; set; }
        public bool IsPaid { get; set; }
        public DateTime TillThisDate { get; set; }
    }
}
