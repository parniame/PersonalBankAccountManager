namespace PersonalBankAccountManager.Models
{
    public class UserWithDetailsViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatorName { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? UpdatorName { get; set; }
        public string? DateCreatedFarsi { get; set; }
        public string? DateUpdatedFarsi { get; set; }
    }
}
