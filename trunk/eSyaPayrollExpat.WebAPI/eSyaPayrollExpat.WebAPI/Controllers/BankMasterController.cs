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
    public class BankMasterController : ControllerBase
    {
        private readonly IBankMasterRepository _BankMasterRepository;
        public BankMasterController(IBankMasterRepository BankMasterRepository)
        {
            _BankMasterRepository = BankMasterRepository;
        }
        #region Bank Master

        /// <summary>
        /// Getting  Bank Master
        /// UI Reffered - Bank Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBankMasterByBusinessKey(int businesskey)
        {
            var bank_master = await _BankMasterRepository.GetBankMasterByBusinessKey(businesskey);
            return Ok(bank_master);
        }
        /// <summary>
        /// Insert Bank Master.
        /// UI Reffered -Bank Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertBankMaster(DO_BankMaster obj)
        {
            var msg = await _BankMasterRepository.InsertBankMaster(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update Bank Master.
        /// UI Reffered -Bank Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateBankMaster(DO_BankMaster obj)
        {
            var msg = await _BankMasterRepository.UpdateBankMaster(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Getting  Currency Master
        /// UI Reffered - Bank Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCurrencyMaster()
        {
            var currency_master = await _BankMasterRepository.GetCurrencyMaster();
            return Ok(currency_master);
        }

        /// <summary>
        /// Getting  Bank Currency
        /// UI Reffered - Bank Master
        /// UI-Param-
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBankCurrencyByBusinessKey(int businesskey,string BankCode)
        {
            var bank_currencies = await _BankMasterRepository.GetBankCurrencyByBusinessKey(businesskey,BankCode);
            return Ok(bank_currencies);
        }
        #endregion Bank Master
    }
}