using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Abstraction.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
       


        protected abstract void Validate();

    }
    public abstract class TraceableBaseEntity<U> : BaseEntity where U : IdentityUser<Guid>
    {

        public U? Creator { get; set; }

        
        public U? Updator { get; set; }
    }
}
