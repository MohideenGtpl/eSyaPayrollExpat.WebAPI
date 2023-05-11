using System;
using System.Collections.Generic;

namespace eSyaPayrollExpat.DL.Entities
{
    public partial class GtEpyemh
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeId { get; set; }
        public string BiometricId { get; set; }
        public string Title { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public bool ExemptedFromAttendance { get; set; }
        public int WillingnessToWorkInShifts { get; set; }
        public byte[] Photo { get; set; }
        public string EmployeeStatus { get; set; }
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
