using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaPayrollExpat.DO
{
   public class DO_AdvanceSalary
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public int PayPeriod { get; set; }
        public decimal SalaryAdvance { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }

    public class DO_VariableIncentive
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public int PayPeriod { get; set; }
        public decimal VariableIncentiveAmount { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
