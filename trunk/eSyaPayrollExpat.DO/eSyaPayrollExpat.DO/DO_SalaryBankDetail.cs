﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaPayrollExpat.DO
{
    public class DO_SalaryBankDetail
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public int PayPeriod { get; set; }
        public int SerialNumber { get; set; }
        public string BankRemittanceCode { get; set; }
        public string BankRemittance { get; set; }
        public string BankCurrencyCode { get; set; }
        public string BankCurrency { get; set; }
        public string AccountHolderName { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string IFSCCode { get; set; }
        public string SWIFTCode { get; set; }
        public string IBAN { get; set; }
        public string CorrespondingBankName { get; set; }
        public string CorrespondingBankAddress { get; set; }
        public string CorrespondingBankAccountNumber { get; set; }

        public decimal SalaryCurrencyAmount { get; set; }
        public decimal LocalCurrencyAmount { get; set; }
        public string OrgBankCode { get; set; }
        public DateTime OrgBankDate { get; set; }
        public bool IsBankChargeApplicable { get; set; }
        public decimal BankCharges { get; set; }

        public bool Status { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }

    }
}
