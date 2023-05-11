using eSyaPayrollExpat.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.IF
{
    public interface ISalaryPaymentRepository
    {
        Task<List<DO_BankMaster>> GetPaymentBankMaster(int businessKey);

        Task<List<DO_Currency>> GetBankCurrency(int businessKey, string bankCode);

        Task<List<DO_SalaryBankDetail>> GetSalaryDetailForPayment(int businessKey, string bankCode, string currency, string bankRemittance);

        Task<DO_ReturnParameter> UpdateSalaryPaymentBank(List<DO_SalaryBankDetail> obj);

        Task<List<DO_SalaryBankDetail>> GetBankStatement(int businessKey, string orgBankCode, DateTime bankDate);

    }
}
