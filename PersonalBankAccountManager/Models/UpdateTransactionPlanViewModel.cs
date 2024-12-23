using PersonalBankAccountManager.Resources.MyAttributes;
using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PersonalBankAccountManager.Models
{
    public class UpdateTransactionPlanViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string UniqueName { get; set; }

        [Display(Name = "AmountProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "OnlyPositive")]
        [RegularExpression("^\\d*(\\.\\d{1,2})?$", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "Onlynumber")]
        public decimal Amount { get; set; }

        public bool IsWithdrawl { get; set; }

        [Display(Name = "TillThisDateProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [DataType(DataType.Date, ErrorMessageResourceName = "InvalidDate", ErrorMessageResourceType = typeof(PresentationResources))]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessageResourceName = "InvalideFutureDate", ErrorMessageResourceType = typeof(PresentationResources))]
        public DateTime? TillThisDate { get; set; }
        public DateTime OldDateTime { get; set; }
        public string TillThisDateFarsi {  get; set; }

        [Display(Name = "DescriptionProp", ResourceType = typeof(PresentationResources))]
        public string? Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
