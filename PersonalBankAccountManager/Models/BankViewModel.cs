using DataTransferObject;
using Models.Entities;
using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class BankViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? URL { get; set; }
    }
    //public static class BankViewModelMapper
    //{
    //    public static BankViewModel MapToBankViewModel(this BankCommand bank)
    //    {
    //        var bankViewModel = new BankViewModel();
    //        bankViewModel.Id = bank.Id;
    //        bankViewModel.Name = bank.Name;
    //        if(bank.Picture != null)
    //        {
    //            bankViewModel.URL = bank.Picture.FileAddress;
    //        }
    //        return bankViewModel;
    //    }
    //}
}
