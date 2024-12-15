using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class UpdateBankAccountViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string Title { get; set; }

        [Display(Name = "BankAccountAmountProp", ResourceType = typeof(PresentationResources))]
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
