using DataTransferObject;
using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class BankAccountViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? URL { get; set; }
        

    }
    //public static class BankAccountViewModelMapper
    //{
    //    public static BankAccountViewModel MapToBankAccountViewModel(this BankAccountCommand bankAccount)
    //    {
    //        var bankAccountViewModel = new BankAccountViewModel();
    //        bankAccountViewModel.Id = bankAccount.Id;
    //        bankAccountViewModel.Title = bankAccount.Title;
    //        if (bankAccount.Bank != null)
    //        {
    //            if (bankAccount.Bank.Picture != null)
    //                bankAccountViewModel.URL = bankAccount.Bank.Picture.FileAddress;
    //        }
    //        bankAccountViewModel.CardNumber = bankAccount.CardNumber;
    //        return bankAccountViewModel;
    //    }
    //}
}
