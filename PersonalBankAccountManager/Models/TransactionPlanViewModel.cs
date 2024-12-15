using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class TransactionPlanViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        public string Name { get; set; }
    }
}
