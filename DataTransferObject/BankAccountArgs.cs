﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BankAccountArgs
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? URL { get; set; }

    }
}
