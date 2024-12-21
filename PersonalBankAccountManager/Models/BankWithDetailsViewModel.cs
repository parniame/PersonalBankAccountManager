namespace PersonalBankAccountManager.Models
{
    public class BankWithDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? URL { get; set; }
        public string? DateCreatedFarsi { get; set; }
        public string? DateUpdatedFarsi { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? CreatorName { get; set; }
        public string? UpdatorName { get; set; }
    }
}
