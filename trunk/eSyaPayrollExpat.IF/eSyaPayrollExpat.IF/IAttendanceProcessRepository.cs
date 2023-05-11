using eSyaPayrollExpat.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.IF
{
   public interface IAttendanceProcessRepository
    {
        Task<List<DO_PayPeriod>> GetPayPeriodbyBusinessKey(int Businesskey);

        Task<List<DO_AttendanceProcess>> GetAttendanceProcessbyBusinessKey(int Businesskey,int Payperiod);

        Task<DO_ReturnParameter> InsertOrUpdateAttendanceProcess(List<DO_AttendanceProcess> obj);
        #region Arrear Details
        Task<List<DO_Arreardays>> GetPaidToEmployees(int Businesskey, int Payperiod, int employeeNumber);
        Task<List<DO_Arreardays>> GetArreardays(int Businesskey, int Payperiod, int employeeNumber);
        Task<DO_ReturnParameter> InsertOrUpdateArreardays(List<DO_Arreardays> obj);
        #endregion Reeear Details
    }
}
