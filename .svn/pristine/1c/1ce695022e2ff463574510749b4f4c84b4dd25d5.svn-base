using eSyaPayrollExpat.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.IF
{
   public interface IBankMasterRepository
    {
        #region Bank Master
        Task<List<DO_BankMaster>> GetBankMasterByBusinessKey(int businesskey);

        Task<DO_ReturnParameter> InsertBankMaster(DO_BankMaster obj);

        Task<DO_ReturnParameter> UpdateBankMaster(DO_BankMaster obj);

        Task<List<DO_CurrencyMaster>> GetCurrencyMaster();

        Task<List<DO_BankCurrency>> GetBankCurrencyByBusinessKey(int businesskey,string BankCode);
        #endregion Bank Master
    }
}
