using System;
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
    public class PayPeriodController : ControllerBase
    {
        private readonly IPayPeriodRepository _PayPeriodRepository;
        public PayPeriodController(IPayPeriodRepository PayPeriodRepository)
        {
            _PayPeriodRepository = PayPeriodRepository;
        }
        /// <summary>
        /// Getting  Pay Period List.
        /// UI Reffered - Pay Period Grid
        /// UI-Param - Businesskey
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPayPeriodsbyBusinessKey(int Businesskey)
        {
            var pay_periods = await _PayPeriodRepository.GetPayPeriodsbyBusinessKey(Businesskey);
            return Ok(pay_periods);
        }

        /// <summary>
        /// Insert Pay Period.
        /// UI Reffered - Pay Period
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertPayPeriod(DO_PayPeriod obj)
        {
            var msg = await _PayPeriodRepository.InsertPayPeriod(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update Pay Period.
        /// UI Reffered - Pay Period
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdatePayPeriod(DO_PayPeriod obj)
        {
            var msg = await _PayPeriodRepository.UpdatePayPeriod(obj);
            return Ok(msg);

        }
    }
}