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
    public class SalaryPaymentController : ControllerBase
    {
        private readonly ISalaryPaymentRepository _salaryPaymentRepository;
        public SalaryPaymentController(ISalaryPaymentRepository salaryPaymentRepository)
        {
            _salaryPaymentRepository = salaryPaymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentBankMaster(int businessKey)
        {
            var rs = await _salaryPaymentRepository.GetPaymentBankMaster(businessKey);
            return Ok(rs);
        }

        [HttpGet]
        public async Task<IActionResult> GetBankCurrency(int businessKey, string bankCode)
        {
            var rs = await _salaryPaymentRepository.GetBankCurrency(businessKey, bankCode);
            return Ok(rs);
        }

        [HttpGet]
        public async Task<IActionResult> GetSalaryDetailForPayment(int businessKey, string bankCode, string currency, string bankRemittance)
        {
            var rs = await _salaryPaymentRepository.GetSalaryDetailForPayment(businessKey, bankCode, currency, bankRemittance);
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSalaryPaymentBank(List<DO_SalaryBankDetail> obj)
        {
            var msg = await _salaryPaymentRepository.UpdateSalaryPaymentBank(obj);
            return Ok(msg);

        }

        [HttpGet]
        public async Task<IActionResult> GetBankStatement(int businessKey, string orgBankCode, DateTime bankDate)
        {
            var rs = await _salaryPaymentRepository.GetBankStatement(businessKey, orgBankCode, bankDate);
            return Ok(rs);
        }

    }
}