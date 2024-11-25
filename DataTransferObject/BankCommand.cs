using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BankCommand
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public Guid? CreatorID { get; set; }
       

        public Guid? UpdatorID { get; set; }
       
    }
}
