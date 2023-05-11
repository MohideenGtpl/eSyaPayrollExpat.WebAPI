﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaPayrollExpat.DO
{
    public class DO_AttendanceProcess
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public int PayPeriod { get; set; }
        public int TotalDays { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal Lopdays { get; set; }
        public bool IsVacationPay { get; set; }
        public decimal VacationDays { get; set; }
        public decimal VacationPayPercentage { get; set; }
        public decimal VaccationPayDays { get; set; }
        public decimal AttendedDays { get; set; }
        public decimal AttendanceFactor { get; set; }
       
        public bool ActiveStatus { get; set; }
        public int Workingdays { get; set; }
        public string EmployeeName { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
    public class DO_Arreardays
    {
        public int BusinessKey { get; set; }
        public int EmployeeNumber { get; set; }
        public int PayPeriod { get; set; }
        public decimal PaidPeriod { get; set; }
        public decimal ArrearDays { get; set; }
        public bool ActiveStatus { get; set; }
        public decimal Lopdays { get; set; }
        //public decimal BalancedaysToPay { get; set; }
        //public decimal NumberofdaysToPay { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
