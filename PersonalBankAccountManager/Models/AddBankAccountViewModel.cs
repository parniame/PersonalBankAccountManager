namespace PersonalBankAccountManager.Models
{
    public class AddBankAccountViewModel
    {
        public BankAccountViewModel BankAccountViewModel { get; set; }
        public List<BankViewModel> BankViewModels { get; set; } = new List<BankViewModel>();
    }
}
