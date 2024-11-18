﻿using Abstraction.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class TransactionPlan : BaseEntity,ITimeTraceble
    {
        public string UniqueName { get; set; }
        public decimal Amount { get; set; }
        public bool IsWithdrawl { get; set; }
        public DateTime TillThisDate { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
