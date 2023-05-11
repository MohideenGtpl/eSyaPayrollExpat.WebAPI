using eSyaPayrollExpat.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.IF
{
   public interface IEmployeeMasterRepository
    {
        #region Employee Master
        Task<List<DO_EmployeeMaster>> GetEmployeeListByNamePrefix(int BusinessKey, string employeeNamePrefix);

        Task<DO_ReturnParameter> InsertOrUpdateEmployeeMaster(DO_EmployeeMaster employeeMaster);

        Task<DO_EmployeeMaster> GetEmployeeDetails(int BusinessKey, int EmployeeNumber);

        Task<DO_ReturnParameter> InsertOrUpdatePersonalInfo(DO_PersonalInfo obj);

        Task<DO_PersonalInfo> GetEmployeePersonalInfo(int BusinessKey, int EmployeeNumber);

        Task<DO_PersonalInfo> GetAddressDetail(int BusinessKey, int EmployeeNumber, string PermanentOrCurrent);

        Task<DO_ReturnParameter> InsertIntoSalaryInfo(DO_SalaryInfo obj);

        Task<DO_SalaryInfo> GetSalaryInfo(int BusinessKey, int EmployeeNumber);

        Task<List<DO_SalaryBreakup>> GetSalaryBreakup(int BusinessKey, int EmployeeNumber);

        Task<DO_ReturnParameter> InsertOrUpdateBankDetail(DO_BankDetail obj);

        Task<List<DO_BankDetail>> GetBankDetail(int BusinessKey, int EmployeeNumber);

        Task<DO_ReturnParameter> InsertOrUpdateCurrentJob(DO_CurrentJob obj);

        Task<List<DO_CurrentJob>> GetCurrentJob(int BusinessKey, int EmployeeNumber);

        Task<DO_ReturnParameter> InsertOrUpdateFixedDeductionInfo(DO_FixedDeductionInfo obj);

        Task<List<DO_FixedDeductionInfo>> GetFixedDeductionInfo(int BusinessKey, int EmployeeNumber);

        #endregion Employee Master
    }
}
