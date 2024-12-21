using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class BankAccountWithoutDetailsViewModel
    {
        public Guid Id { get; set; }        
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        public string Title { get; set; }

        [Display(Name = "BankAccountAmountProp", ResourceType = typeof(PresentationResources))]
        public decimal Amount { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? DateCreatedFarsi {  get; set; }
        public string? DateUpdatedFarsi { get; set; }
        public DateTime? DateUpdated { get; set; }


    }
}
