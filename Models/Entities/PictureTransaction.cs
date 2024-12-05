using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities
{
    public class PictureTransaction
    {
        public Guid TransactionId { get; set; }
        public Guid PictureId { get; set; }
    }
}
