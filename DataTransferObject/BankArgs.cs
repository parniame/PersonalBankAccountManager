using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BankArgs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? URL { get; set; }
        public PictureArgs Picture { get; set; }
    }
}
