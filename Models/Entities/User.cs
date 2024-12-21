using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateCreated { get; set; }
        public Guid? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UpdatorID { get; set; }
        public User? Updator { get; set; }
       
        

    }
}
