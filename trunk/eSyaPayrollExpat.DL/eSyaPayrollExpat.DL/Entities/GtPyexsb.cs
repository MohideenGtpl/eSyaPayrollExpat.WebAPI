﻿using System;
using System.Collections.Generic;

namespace eSyaPayrollExpat.DL.Entities
{
    public partial class GtPyexsb
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public int SerialNumber { get; set; }
        public string PaymentByCurrency { get; set; }
        public decimal PaymentAmountBySalaryCurrency { get; set; }
        public string TransferTo { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
