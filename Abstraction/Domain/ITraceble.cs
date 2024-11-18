using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Domain;
using Microsoft.AspNetCore.Identity;


namespace Domain
{
    public interface ITraceble <U> where U : IdentityUser<Guid>
    {

        public Guid? CreatorID { get; set; }
        public U? Creator { get; set; }

        public Guid? UpdatorID { get; set; }
        public U? Updator { get; set; }
    }
}
