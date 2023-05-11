using System;
using System.Collections.Generic;

namespace eSyaPayrollExpat.DL.Entities
{
    public partial class GtPyexbd
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public int SerialNumber { get; set; }
        public string BankRemittance { get; set; }
        public string BankCurrency { get; set; }
        public string AccountHolderName { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string Ifsccode { get; set; }
        public string Swiftcode { get; set; }
        public string Iban { get; set; }
        public string CorrespondingBankName { get; set; }
        public string CorrespondingBankAddress { get; set; }
        public string CorrespondingBankAccountNumber { get; set; }
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
