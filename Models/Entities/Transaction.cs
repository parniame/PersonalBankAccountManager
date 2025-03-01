﻿using Abstraction.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid UserId { get; set; }
        public bool IsWithdrawl { get; set; }
        public string Title { get; set; }
        public Guid BankAccountId { get; set; } 
        public decimal Amount { get; set; }
        public Guid?  CategoryId { get; set; }
        public string? Description { get; set; }
        //public Guid? SecondBankAccountId { get; set; }
        public Guid? TransactionPlanId { get; set; }
        public Guid? PictureId { get; set; }
        public Picture? TransActionDocument { get; private set; }
       
        public TransactionCategory Category { get; set; }
        public TransactionPlan TransactionPlan { get; set; }
        public BankAccount BankAccount { get; set; }
        //public BankAccount SecondBankAccount { get; set; }
        
        
    }
}
