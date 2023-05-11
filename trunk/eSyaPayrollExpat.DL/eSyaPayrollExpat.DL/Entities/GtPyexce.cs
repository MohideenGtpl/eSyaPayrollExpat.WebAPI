﻿using System;
using System.Collections.Generic;

namespace eSyaPayrollExpat.DL.Entities
{
    public partial class GtPyexce
    {
        public int BusinessKey { get; set; }
        public int PayPeriod { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
