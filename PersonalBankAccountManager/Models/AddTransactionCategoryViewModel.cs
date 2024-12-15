using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class AddTransactionCategoryViewModel
    {
        
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Name { get; set; }
        public bool IsWithdrawl { get; set; }
    }
}
