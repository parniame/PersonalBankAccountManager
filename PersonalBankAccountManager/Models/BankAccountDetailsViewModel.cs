using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class BankAccountDetailsViewModel
    {
        public string? URL { get; set; }
        [Display(Name = "CardNumberProp", ResourceType = typeof(PresentationResources))]
        [RegularExpression("[2569]{1}[\\d]{15}", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "InvalidCardNumber")]
        public string? CardNumber { get; set; }
        [Display(Name = "BankNameProp", ResourceType = typeof(PresentationResources))]
        public string? BankName { get; set; }
        [Display(Name = "DescriptionProp", ResourceType = typeof(PresentationResources))]
        public string? Description { get; set; }
        
    }
}
