﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaPayrollExpat.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaPayrollExpat.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonDataController : ControllerBase
    {

        private readonly ICommonDataRepository _commonDataRepository;
        public CommonDataController(ICommonDataRepository commonDataRepository)
        {
            _commonDataRepository = commonDataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codeType)
        {
            var ds = await _commonDataRepository.GetApplicationCodesByCodeType(codeType);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> GetApplicationCodesByCodeTypeList(List<int> l_codeType)
        {
            var ds = await _commonDataRepository.GetApplicationCodesByCodeTypeList(l_codeType);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessKey()
        {
            var ds = await _commonDataRepository.GetBusinessKey();
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetISDCodes()
        {
            var ds = await _commonDataRepository.GetISDCodes();
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveCurrencyList()
        {
            var ds = await _commonDataRepository.GetActiveCurrencyList();
            return Ok(ds);
        }
    }
}