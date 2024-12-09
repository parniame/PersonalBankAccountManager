using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class AddBankAccountViewModel
    {
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Title { get; set; }

        [Display(Name = "BankAccountAmountProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "OnlyPositive")]
        [RegularExpression("^\\d*(\\.\\d{1,2})?$", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "Onlynumber")]
        public decimal Amount { get; set; }
 
        public Guid? BankId { get; set; }

        [Display(Name = "DescriptionProp", ResourceType = typeof(PresentationResources))]
        public string? Description { get; set; }
        [Display(Name = "CardNumberProp", ResourceType = typeof(PresentationResources))]
        [RegularExpression("[2569]{1}[\\d]{15}", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "InvalidCardNumber")]
        public string? CardNumber { get; set; }
        public List<BankViewModel> BankViewModels { get; set; } = new List<BankViewModel>();

    }
}
