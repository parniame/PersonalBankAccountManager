using PersonalBankAccountManager.Resources.MyAttributes;
using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class TransactionPlanWithoutDetails
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Name { get; set; }

        [Display(Name = "AmountProp", ResourceType = typeof(PresentationResources))]
        public decimal Amount { get; set; }
        public string IsWithdrawl { get; set; }
        public string TillThisDateFarsi { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsPaid { get; set; }
        public string? DateCreatedFarsi { get; set; }
        public string? DateUpdatedFarsi { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        
    }
}
