using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CategoryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsWithdrawl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? CreatorName { get; set; }
        public string? UpdatorName { get; set; }
    }
}
