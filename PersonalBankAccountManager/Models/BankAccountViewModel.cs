using DataTransferObject;
using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class BankAccountViewModel
    {
        [Display(Name = "NameProp", ResourceType = typeof(PresentationResources))]
        public string Title { get; set; }

        [Display(Name = "BankProp", ResourceType = typeof(PresentationResources))]
        public string? Url { get; set; }

        [Display(Name = "CardNumberProp", ResourceType = typeof(PresentationResources))]
        public string? CardNumber { get; set; }
    }
    public static class BankAccountViewModelMapper
    {
        public static BankAccountViewModel MapToBankAccountViewModel(this BankAccountCommand bankAccount)
        {
           var bankAccountViewModel  = new BankAccountViewModel();
            bankAccountViewModel.Title = bankAccount.Title;
            if(bankAccount.BankPicture != null)
            {
                bankAccountViewModel.Url = bankAccount.BankPicture.FileAddress;
            }
            bankAccountViewModel.CardNumber = bankAccount.CardNumber;
            return bankAccountViewModel;
        }
    }
}
