using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Domain
{
    public interface ITimeTraceble    {
        DateTime? DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}
