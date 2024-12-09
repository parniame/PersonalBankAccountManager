using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TransactionCategoryCommand
    {
        public Guid Id { get; set; }
        public bool IsWithdrawl { get; set; }
        public string Name { get; set; }

        public Guid? CreatorID { get; set; }
        public Guid? UpdatorID { get; set; }

    }
}
