using eSyaPayrollExpat.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.IF
{
    public interface IPayrollProcessRepository
    {
        Task<List<DO_Currency>> GetCurrencyExchangeRate(int businessKey, int payPeriod);

        Task<List<DO_PayrollProcess>> GetEmployeeForPayrollProcess(int businessKey, int payPeriod);

        Task<List<DO_PayrollProcess>> GetPayrollProcessedEmployee(int businessKey, int payPeriod);

        Task<List<DO_PayrollProcess>> GetEmployeeForPayrollProcess_Redo(int businessKey, int payPeriod);

        Task<DO_ReturnParameter> InsertIntoPayrollProcess(List<DO_PayrollProcess> obj);

        Task<List<DO_PayrollProcess>> GetSalaryRegister(int businessKey, int payPeriod);

    }
}
