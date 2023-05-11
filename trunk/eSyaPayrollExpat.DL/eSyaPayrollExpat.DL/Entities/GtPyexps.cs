﻿using System;
using System.Collections.Generic;

namespace eSyaPayrollExpat.DL.Entities
{
    public partial class GtPyexps
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public int PayPeriod { get; set; }
        public DateTime ProcessedDate { get; set; }
        public string SalaryCurrency { get; set; }
        public decimal SalaryAmount { get; set; }
        public decimal AttendanceFactor { get; set; }
        public bool IsVacationPay { get; set; }
        public decimal ProcessedAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountInLocalCurrency { get; set; }
        public decimal VariableIncentiveAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public bool Bcdebit { get; set; }
        public decimal BankCharges { get; set; }
        public decimal NetSalaryAmount { get; set; }
        public decimal Nhifamount { get; set; }
        public decimal Nssfamount { get; set; }
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
