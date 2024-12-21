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
   
}
