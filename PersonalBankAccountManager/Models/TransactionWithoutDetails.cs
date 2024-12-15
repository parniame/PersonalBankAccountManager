namespace PersonalBankAccountManager.Models
{
    public class TransactionWithoutDetails
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string IsWithdrawl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public BankAccountViewModel BankAccount { get; set; }
    }
}
