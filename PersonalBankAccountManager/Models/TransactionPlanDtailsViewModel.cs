namespace PersonalBankAccountManager.Models
{
    public class TransactionPlanDtailsViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        
        public DateTime? DateUpdated { get; set; }
        public BankAccountViewModel BankAccount { get; set; }
        public string? TransactionDescription { get; set; }
    }
}
