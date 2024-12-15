using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class UpdateTransactionViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Title { get; set; }

        [Display(Name = "AmountProp", ResourceType = typeof(PresentationResources))]
        public decimal Amount { get; set; }

        public bool IsWithdrawl { get; set; }

        [Display(Name = "DescriptionProp", ResourceType = typeof(PresentationResources))]
        public string? Description { get; set; }
        
        public Guid? CategoryId { get; set; }
        //public Guid? SecondBankAccountId { get; set; }
        
        public List<CategoryViewModel>? Categories { get; set; }
        public TransactionPlanViewModel? TransactionPlanViewModel { get; set; }
        public BankAccountViewModel? BankAccountViewModel { get; set; } 
        
    }
}
