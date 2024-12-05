namespace PersonalBankAccountManager.Models
{
    public class AddTransactionViewModel
    {
        public bool IsWithdrawl { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public Guid BankAccountId { get; set; }
        //public Guid? CategoryId { get; set; }
        //public Guid? SecondBankAccountId { get; set; }
        //public Guid? TransactionPlanId { get; set; }

        public List<BankAccountViewModel> BankAccountViewModels { get; set; }
    }
}
