using Abstraction.Domain;


namespace Models.Entities
{

    public class Bank: BaseEntity
    {
        public string Name { get; private set; }
        //public Guid PictureId { get; private set; }
        public Guid? CreatorID { get; set; }
        public Guid? UpdatorID { get; set; }
        public Guid? PictureId { get; set; }

        public Picture? Picture { get; private set; }
        public User? Creator { get; set; }
        public User? Updator { get; set; }
        


       
    }
}
