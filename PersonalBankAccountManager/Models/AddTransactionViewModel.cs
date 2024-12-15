using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class AddTransactionViewModel
    {
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Title { get; set; }

        [Display(Name = "AmountProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "OnlyPositive")]
        [RegularExpression("^\\d*(\\.\\d{1,2})?$", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "Onlynumber")]
        public decimal Amount { get; set; }

        public bool IsWithdrawl { get; set; }

        [Display(Name = "DescriptionProp", ResourceType = typeof(PresentationResources))]
        public string? Description { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid? CategoryId { get; set; }
        //public Guid? SecondBankAccountId { get; set; }
        public Guid? TransactionPlanId { get; set; }

        public List<BankAccountViewModel> BankAccountViewModels { get; set; } = new List<BankAccountViewModel>();
        public List<TransactionPlanWithoutDetails> TransactionPlanViewModels { get; set;} = new List<TransactionPlanWithoutDetails>();
        
    }
}
