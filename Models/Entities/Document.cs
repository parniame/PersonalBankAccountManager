
using Abstraction.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Owned]
    public class Document : ValueObject
    {
        public Guid Id { get; set; }
        public string FileAddress { get; private set; }
        public Guid TransactionId { get; set; }
       

        public Document(string fileAddress)
        {
            if (string.IsNullOrEmpty(fileAddress)) 
                throw new ArgumentNullException(nameof(fileAddress));
           

            FileAddress = fileAddress;
            
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FileAddress;
          
        }
    }
}
