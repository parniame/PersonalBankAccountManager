using PersonalBankAccountManager.Resources.MyAttributes;
using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class TransactionPlanWithoutDetails
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        public string Name { get; set; }

        [Display(Name = "AmountProp", ResourceType = typeof(PresentationResources))]
        public decimal Amount { get; set; }

        public bool IsWithdrawl { get; set; }

        [Display(Name = "TillThisDateProp", ResourceType = typeof(PresentationResources))]
        [DataType(DataType.Date, ErrorMessageResourceName = "InvalidDate", ErrorMessageResourceType = typeof(PresentationResources))]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessageResourceName = "InvalideFutureDate", ErrorMessageResourceType = typeof(PresentationResources))]
        public DateTime TillThisDate { get; set; }
    }
}
