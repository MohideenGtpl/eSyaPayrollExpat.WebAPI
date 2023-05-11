using eSyaPayrollExpat.DL.Entities;
using eSyaPayrollExpat.DO;
using eSyaPayrollExpat.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.DL.Repository
{
   public class PayPeriodRepository: IPayPeriodRepository
    {
        public async Task<List<DO_PayPeriod>> GetPayPeriodsbyBusinessKey(int Businesskey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtPyexpp.Where(x=>x.BusinessKey== Businesskey).Select(
                      x => new DO_PayPeriod
                      {
                          BusinessKey = x.BusinessKey,
                          PayPeriod = x.PayPeriod,
                          WorkingDays = x.WorkingDays,
                          IsPayrollFreezed = x.IsPayrollFreezed,
                          IsFinancePosted = x.IsFinancePosted,
                          ActiveStatus = x.ActiveStatus
                      }).ToListAsync();
                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertPayPeriod(DO_PayPeriod obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtPyexpp is_payperiodExists = db.GtPyexpp.FirstOrDefault(p =>p.BusinessKey == obj.BusinessKey && p.PayPeriod==obj.PayPeriod);
                        if (is_payperiodExists == null)
                        {
                            var payperiod = new GtPyexpp
                            {
                                BusinessKey = obj.BusinessKey,
                                PayPeriod = obj.PayPeriod,
                                WorkingDays = obj.WorkingDays,
                                IsPayrollFreezed = obj.IsPayrollFreezed,
                                IsFinancePosted = obj.IsFinancePosted,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtPyexpp.Add(payperiod);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Pay Period Created Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Pay Period is already Exists in this Business Key." };
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdatePayPeriod(DO_PayPeriod obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        var pay_period = db.GtPyexpp.FirstOrDefault(p => p.BusinessKey == obj.BusinessKey && p.PayPeriod == obj.PayPeriod);
                        if (pay_period != null)
                        {
                            pay_period.BusinessKey = obj.BusinessKey;
                            pay_period.PayPeriod = obj.PayPeriod;
                            pay_period.WorkingDays = obj.WorkingDays;
                            pay_period.IsPayrollFreezed = obj.IsPayrollFreezed;
                            pay_period.IsFinancePosted = obj.IsFinancePosted;
                            pay_period.ActiveStatus = obj.ActiveStatus;
                            pay_period.ModifiedBy = obj.UserID;
                            pay_period.ModifiedOn = DateTime.Now;
                            pay_period.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Pay Period Updated Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Pay Period." };
                        }

                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
