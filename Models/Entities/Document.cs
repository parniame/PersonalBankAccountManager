
using Abstraction.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    
    public class Document : BaseEntity
    {
        public Guid Id { get; set; }
        public string FileAddress { get; private set; }
        public Guid TransactionId { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }


        //public Document(string fileAddress)
        //{
        //    if (string.IsNullOrEmpty(fileAddress)) 
        //        throw new ArgumentNullException(nameof(fileAddress));


        //    FileAddress = fileAddress;

        //}

        //protected override IEnumerable<object?> GetEqualityComponents()
        //{
        //    yield return FileAddress;

        //}
    }
}
