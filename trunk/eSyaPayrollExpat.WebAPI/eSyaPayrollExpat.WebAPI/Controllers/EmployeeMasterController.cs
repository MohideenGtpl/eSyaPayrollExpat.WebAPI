﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eSyaPayrollExpat.DO;
using eSyaPayrollExpat.IF;

namespace eSyaPayrollExpat.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeMasterRepository _EmployeeMasterRepository;
        public EmployeeMasterController(IEmployeeMasterRepository EmployeeMasterRepository)
        {
            _EmployeeMasterRepository = EmployeeMasterRepository;
        }

        #region Employee Master

        /// <summary>
        /// Getting  Employee Master List.
        /// UI Reffered - Employee Master Grid
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetEmployeeListByNamePrefix(int BusinessKey, string employeeNamePrefix)
        {
            var employee_master = await _EmployeeMasterRepository.GetEmployeeListByNamePrefix(BusinessKey, employeeNamePrefix);
            return Ok(employee_master);
        }

        /// <summary>
        /// Insert Employee Master.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateEmployeeMaster(DO_EmployeeMaster obj)
        {
            var msg = await _EmployeeMasterRepository.InsertOrUpdateEmployeeMaster(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Get Employee Master by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int BusinessKey, int EmployeeNumber)
        {
            var employee_Master = await _EmployeeMasterRepository.GetEmployeeDetails(BusinessKey, EmployeeNumber);
            return Ok(employee_Master);
        }

        //// <summary>
        /// Insert Employee Personal Detail.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdatePersonalInfo(DO_PersonalInfo obj)
        {
            var msg = await _EmployeeMasterRepository.InsertOrUpdatePersonalInfo(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Get Employee Personal Info by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployeePersonalInfo(int BusinessKey, int EmployeeNumber)
        {
            var employee_PersonalInfo = await _EmployeeMasterRepository.GetEmployeePersonalInfo(BusinessKey, EmployeeNumber);
            return Ok(employee_PersonalInfo);
        }

        /// <summary>
        /// Get Employee Personal Info by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAddressDetail(int BusinessKey, int EmployeeNumber, string PermanentOrCurrent)
        {
            var employee_AddressDetail = await _EmployeeMasterRepository.GetAddressDetail(BusinessKey, EmployeeNumber, PermanentOrCurrent);
            return Ok(employee_AddressDetail);
        }

        //// <summary>
        /// Insert Employee Salary Info.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoSalaryInfo(DO_SalaryInfo obj)
        {
            var msg = await _EmployeeMasterRepository.InsertIntoSalaryInfo(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Get Employee Salary Info by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSalaryInfo(int BusinessKey, int EmployeeNumber)
        {
            var employee_SalaryInfo = await _EmployeeMasterRepository.GetSalaryInfo(BusinessKey, EmployeeNumber);
            return Ok(employee_SalaryInfo);
        }

        /// <summary>
        /// Getting  Employee Salary Breakup List  by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSalaryBreakup(int BusinessKey, int EmployeeNumber)
        {
            var employee_SalaryBreakup = await _EmployeeMasterRepository.GetSalaryBreakup(BusinessKey, EmployeeNumber);
            return Ok(employee_SalaryBreakup);
        }

        //// <summary>
        /// Insert Employee Bank Detail.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateBankDetail(DO_BankDetail obj)
        {
            var msg = await _EmployeeMasterRepository.InsertOrUpdateBankDetail(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Getting  Employee Bank Details by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBankDetail(int BusinessKey, int EmployeeNumber)
        {
            var employee_BankDetail = await _EmployeeMasterRepository.GetBankDetail(BusinessKey, EmployeeNumber);
            return Ok(employee_BankDetail);
        }

        //// <summary>
        /// Insert Employee Current Job.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateCurrentJob(DO_CurrentJob obj)
        {
            var msg = await _EmployeeMasterRepository.InsertOrUpdateCurrentJob(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Getting  Employee Current Job Details by Employee Number.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCurrentJob(int BusinessKey, int EmployeeNumber)
        {
            var employee_CurrentJob = await _EmployeeMasterRepository.GetCurrentJob(BusinessKey, EmployeeNumber);
            return Ok(employee_CurrentJob);
        }

        //// <summary>
        /// Insert Employee Fixed Deduction.
        /// UI Reffered - Employee Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateFixedDeductionInfo(DO_FixedDeductionInfo obj)
        {
            var msg = await _EmployeeMasterRepository.InsertOrUpdateFixedDeductionInfo(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Getting  EmployeeFixed Deduction Information by Employee Number.
        /// UI Reffered - Employee Master
        /// UI-Params-BusinessKey && EmployeeNumber
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFixedDeductionInfo(int BusinessKey,int EmployeeNumber)
        {
            var fixed_deductions = await _EmployeeMasterRepository.GetFixedDeductionInfo(BusinessKey,EmployeeNumber);
            return Ok(fixed_deductions);
        }


        #endregion Employee Master
    }
}