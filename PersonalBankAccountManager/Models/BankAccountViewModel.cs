using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class BankAccountViewModel
    {
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Title { get; set; }

        [Display(Name = "BankAccountAmountProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "OnlyPositive")]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "Onlynumber")]
        public decimal Amount { get; set; }

        [Display(Name = "BankProp", ResourceType = typeof(PresentationResources))]
        public Guid? BankId { get; set; }

        [Display(Name = "DescriptionProp", ResourceType = typeof(PresentationResources))]
        public string? Description { get; set; }
        [Display(Name = "CardNumberProp", ResourceType = typeof(PresentationResources))]
        public string? CardNumber { get; set; }
        public List<BankViewModel> BankViewModels { get; set; } = new List<BankViewModel>();

    }
}
