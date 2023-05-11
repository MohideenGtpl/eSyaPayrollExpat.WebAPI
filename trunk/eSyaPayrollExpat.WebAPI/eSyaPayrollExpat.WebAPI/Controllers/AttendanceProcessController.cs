﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaPayrollExpat.DO;
using eSyaPayrollExpat.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaPayrollExpat.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceProcessController : ControllerBase
    {
        private readonly IAttendanceProcessRepository _AttendanceProcessRepository;
        public AttendanceProcessController(IAttendanceProcessRepository AttendanceProcessRepository)
        {
            _AttendanceProcessRepository = AttendanceProcessRepository;
        }

        /// <summary>
        /// Getting  Pay Period for dropdown List.
        /// UI Reffered - Attendance Process 
        /// UI-Param- Business Key
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPayPeriodbyBusinessKey(int Businesskey)
        {
            var pay_periods = await _AttendanceProcessRepository.GetPayPeriodbyBusinessKey(Businesskey);
            return Ok(pay_periods);
        }

        /// <summary>
        /// Getting  Attendance Process List.
        /// UI Reffered - Attendance Process Grid
        ///  /// UI-Param- Business Key,Pay Period
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAttendanceProcessbyBusinessKey(int Businesskey,int Payperiod)
        {
            var att_process = await _AttendanceProcessRepository.GetAttendanceProcessbyBusinessKey(Businesskey, Payperiod);
            return Ok(att_process);
        }

        /// <summary>
        /// Insert Attendance Process.
        /// UI Reffered - Attendance Process
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateAttendanceProcess(List<DO_AttendanceProcess> obj)
        {
            var msg = await _AttendanceProcessRepository.InsertOrUpdateAttendanceProcess(obj);
            return Ok(msg);

        }
        #region Arrear Details
        /// <summary>
        /// Getting  Paid To.
        /// UI Reffered - Paid To Grid
        ///  /// UI-Param- Business Key,Pay Period,employeeNumber
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPaidToEmployees(int Businesskey, int Payperiod, int employeeNumber)
        {
            var paidto_days = await _AttendanceProcessRepository.GetPaidToEmployees(Businesskey, Payperiod, employeeNumber);
            return Ok(paidto_days);
        }

        /// <summary>
        /// Getting  Arrear Details.
        /// UI Reffered - Paid Grid
        ///  /// UI-Param- Business Key,Pay Period,employeeNumber
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetArreardays(int Businesskey, int Payperiod, int employeeNumber)
        {
            var arrear_details = await _AttendanceProcessRepository.GetArreardays(Businesskey, Payperiod, employeeNumber);
            return Ok(arrear_details);
        }

        /// <summary>
        /// Insert or Update Arrear days.
        /// UI Reffered - Paid To Grid
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateArreardays(List<DO_Arreardays> obj)
        {
            var msg = await _AttendanceProcessRepository.InsertOrUpdateArreardays(obj);
            return Ok(msg);

        }
        #endregion Arrear Details
    }
}