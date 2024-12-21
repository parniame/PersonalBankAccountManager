namespace PersonalBankAccountManager.Models
{
    public class TransactionPlanDtailsViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? TransactionDateCreatedFarsi { get; set; }
        public string? DateUpdatedFarsi { get; set; }
        public BankAccountViewModel BankAccount { get; set; }
        public string? TransactionDescription { get; set; }
    }
}
