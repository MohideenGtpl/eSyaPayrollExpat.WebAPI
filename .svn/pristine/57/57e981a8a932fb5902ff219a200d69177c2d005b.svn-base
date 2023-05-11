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
    public class VariableEntryRepository : IVariableEntryRepository
    {
        #region Salary Advance

        public async Task<List<DO_EmployeeMaster>> GetEmployeesbyBusinessKey(int Businesskey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtPyexem.Where(e => e.ActiveStatus == true && e.BusinessKey== Businesskey)
                        .Select(x=> new DO_EmployeeMaster
                        {
                           EmployeeNumber=x.EmployeeNumber,
                           EmployeeName=x.EmployeeName
                        }).OrderBy(x=>x.EmployeeName).ToListAsync();

                    return await ds;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_AdvanceSalary>> GetSalariesbyBusinessKeyAndPayPeriod(int Businesskey ,int Payperiod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtPyexva.Where(x => x.BusinessKey == Businesskey && x.PayPeriod == Payperiod)
                        .Join(db.GtPyexem.Where(x => x.BusinessKey == Businesskey),
                         x => new { x.BusinessKey, x.EmployeeNumber },
                         y => new { y.BusinessKey, y.EmployeeNumber },
                        (x, y) => new DO_AdvanceSalary
                        {
                            BusinessKey = x.BusinessKey,
                            EmployeeNumber = x.EmployeeNumber,
                            EmployeeName = y.Title + "." + y.EmployeeName,
                            PayPeriod = x.PayPeriod,
                            SalaryAdvance = x.SalaryAdvance,
                            ActiveStatus = x.ActiveStatus,
                        }).OrderBy(o => o.EmployeeName).ToListAsync();

                    return await ds;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertAdvanceSalary(DO_AdvanceSalary obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var o = obj;
                        var pp = db.GtPyexpp.Where(w => w.BusinessKey == o.BusinessKey && w.PayPeriod == o.PayPeriod).FirstOrDefault();
                        if (pp != null)
                        {
                            if (pp.IsPayrollFreezed)
                                return new DO_ReturnParameter() { Status = false, Message = "Payroll is Freezed. can't make changes." };
                        }

                        GtPyexva _isvarExists = db.GtPyexva.FirstOrDefault(v => v.BusinessKey == obj.BusinessKey && v.PayPeriod == obj.PayPeriod && v.EmployeeNumber == obj.EmployeeNumber);

                        if (_isvarExists == null)
                        {
                            var var_Entry = new GtPyexva
                            {
                                BusinessKey = obj.BusinessKey,
                                EmployeeNumber = obj.EmployeeNumber,
                                PayPeriod = obj.PayPeriod,
                                SalaryAdvance = obj.SalaryAdvance,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtPyexva.Add(var_Entry);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Advance Salary Created Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Advance Salary is already Exists." };
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

        public async Task<DO_ReturnParameter> UpdateAdvanceSalary(DO_AdvanceSalary obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var o = obj;
                        var pp = db.GtPyexpp.Where(w => w.BusinessKey == o.BusinessKey && w.PayPeriod == o.PayPeriod).FirstOrDefault();
                        if (pp != null)
                        {
                            if (pp.IsPayrollFreezed)
                                return new DO_ReturnParameter() { Status = false, Message = "Payroll is Freezed. can't make changes." };
                        }

                        GtPyexva ad_sal = db.GtPyexva.FirstOrDefault(v => v.BusinessKey == obj.BusinessKey && v.PayPeriod == obj.PayPeriod && v.EmployeeNumber == obj.EmployeeNumber);

                        if (ad_sal != null)
                        {
                            ad_sal.SalaryAdvance = obj.SalaryAdvance;
                            ad_sal.ActiveStatus = obj.ActiveStatus;
                            ad_sal.ModifiedBy = obj.UserID;
                            ad_sal.ModifiedOn = System.DateTime.Now;
                            ad_sal.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Advance Salary Updated Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Advance Salary." };
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

        #endregion Salary Advance

        #region Variable Incentive

     public async Task<List<DO_VariableIncentive>> GetIncentiesbyBusinessKeyAndPayPeriod(int Businesskey, int Payperiod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                  var result = await db.GtPyexem.Where(x => x.BusinessKey == Businesskey && x.ActiveStatus == true)
                  .Join(db.GtPyexsi.Where(x => x.BusinessKey == Businesskey && x.IsIncentiveApplicable == true), p => p.EmployeeNumber, pc => pc.EmployeeNumber, (p, pc) => new { p, pc })
                  .GroupJoin(db.GtPyexvi.Where(x => x.BusinessKey == Businesskey && x.PayPeriod == Payperiod),
                   m => m.p.EmployeeNumber,
                           l => l.EmployeeNumber,
                           (m, l) => new
                           { m, l }).SelectMany(z => z.l.DefaultIfEmpty(),
                           (a, b) => new DO_VariableIncentive
                           {
                               EmployeeName = a.m.p.Title + "." + a.m.p.EmployeeName,
                               EmployeeNumber =  a.m.p.EmployeeNumber,
                               BusinessKey= a.m.pc.BusinessKey,
                               PayPeriod = b != null ? b.PayPeriod : 0,
                               VariableIncentiveAmount = b != null ? b.VariableIncentiveAmount : 0,
                               ActiveStatus = b != null ? b.ActiveStatus : false
                           }).OrderBy(o=>o.EmployeeName).ToListAsync();

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateVariableIncentive(List<DO_VariableIncentive> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        foreach (var vi in obj.Where(x => x.PayPeriod != 0 && x.BusinessKey != 0 && x.EmployeeNumber!=0 && x.VariableIncentiveAmount!=0))
                        {
                            GtPyexvi v_inc = db.GtPyexvi.Where(x => x.BusinessKey == vi.BusinessKey
                                            && x.PayPeriod== vi.PayPeriod && x.EmployeeNumber== vi.EmployeeNumber).FirstOrDefault();
                            if (v_inc == null)
                            {
                                var add = new GtPyexvi
                                {
                                    BusinessKey = vi.BusinessKey,
                                    PayPeriod = vi.PayPeriod,
                                    EmployeeNumber = vi.EmployeeNumber,
                                    VariableIncentiveAmount=vi.VariableIncentiveAmount,
                                    ActiveStatus = vi.ActiveStatus,
                                    FormId = vi.FormId,
                                    CreatedBy = vi.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = vi.TerminalID
                                };
                                db.GtPyexvi.Add(add);
                            }
                            else
                            {
                                v_inc.VariableIncentiveAmount = vi.VariableIncentiveAmount;
                                v_inc.ActiveStatus = vi.ActiveStatus;
                                v_inc.ModifiedBy = vi.UserID;
                                v_inc.ModifiedOn = System.DateTime.Now;
                                v_inc.ModifiedTerminal = vi.TerminalID;
                            }
                            await db.SaveChangesAsync();
                        }

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
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



        //public async Task<List<DO_VariableIncentive>> GetIncentiesbyBusinessKeyAndPayPeriod(int Businesskey, int Payperiod)
        //{
        //    try
        //    {
        //        using (var db = new eSyaEnterprise())
        //        {
        //            var ds = db.GtPyexvi.Where(x => x.BusinessKey == Businesskey && x.PayPeriod==Payperiod).Join(db.GtPyexem.Where(x => x.BusinessKey == Businesskey),
        //                 x => x.EmployeeNumber,
        //                 y => y.EmployeeNumber,
        //                (x, y) => new DO_VariableIncentive
        //                {
        //                    BusinessKey = x.BusinessKey,
        //                    EmployeeNumber = x.EmployeeNumber,
        //                    EmployeeName = y.EmployeeName,
        //                    PayPeriod = x.PayPeriod,
        //                    VariableIncentiveAmount = x.VariableIncentiveAmount,
        //                    ActiveStatus = x.ActiveStatus,
        //                }).ToListAsync();

        //            return await ds;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<DO_VariableIncentive> GetIncentiesbyBusinessKeyAndPayPeriod(int Businesskey, int Payperiod)
        //{
        //    try
        //    {
        //        using (var db = new eSyaEnterprise())
        //        {
        //            var result = db.GtPyexsi.Where(x => x.BusinessKey == Businesskey && x.IsIncentiveApplicable == true).Join(db.GtPyexem.Where(x => x.BusinessKey == Businesskey && x.ActiveStatus == true),
        //                 x => x.EmployeeNumber,
        //                 y => y.EmployeeNumber,
        //                (x, y) => new DO_VariableIncentive
        //                {
        //                    BusinessKey = x.BusinessKey,
        //                    EmployeeNumber = x.EmployeeNumber,
        //                    EmployeeName = y.EmployeeName,

        //                }).ToList()
        //                .GroupJoin(db.GtPyexvi.Where(x => x.BusinessKey == Businesskey && x.PayPeriod == Payperiod),
        //                    a => a.EmployeeNumber,
        //                    f => f.EmployeeNumber,
        //                    (a, f) => new { a, f = f.FirstOrDefault() })
        //                    .Select(r => new DO_VariableIncentive
        //                    {
        //                        BusinessKey = r.f.BusinessKey,
        //                        EmployeeNumber = r.f.EmployeeNumber,
        //                        PayPeriod = r.f.PayPeriod,
        //                        VariableIncentiveAmount = r.f.VariableIncentiveAmount,
        //                        ActiveStatus = r.f.ActiveStatus,
        //                        EmployeeName = r.a.EmployeeName
        //                    }).ToList();
        //            var Distinctemps = result.GroupBy(x => x.EmployeeNumber).Select(y => y.First());
        //            return Distinctemps.ToList();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<DO_ReturnParameter> InsertVariableIncentive(DO_VariableIncentive obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var o = obj;
                        var pp = db.GtPyexpp.Where(w => w.BusinessKey == o.BusinessKey && w.PayPeriod == o.PayPeriod).FirstOrDefault();
                        if (pp != null)
                        {
                            if (pp.IsPayrollFreezed)
                                return new DO_ReturnParameter() { Status = false, Message = "Payroll is Freezed. can't make changes." };
                        }

                        GtPyexvi _isIncentiveExists = db.GtPyexvi.FirstOrDefault(v => v.BusinessKey == obj.BusinessKey && v.PayPeriod == obj.PayPeriod && v.EmployeeNumber == obj.EmployeeNumber);

                        if (_isIncentiveExists == null)
                        {
                            var var_Incentive = new GtPyexvi
                            {
                                BusinessKey = obj.BusinessKey,
                                EmployeeNumber = obj.EmployeeNumber,
                                PayPeriod = obj.PayPeriod,
                                VariableIncentiveAmount = obj.VariableIncentiveAmount,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtPyexvi.Add(var_Incentive);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Incentive Created Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Incentive is already Exists." };
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

        public async Task<DO_ReturnParameter> UpdateVariableIncentive(DO_VariableIncentive obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var o = obj;
                        var pp = db.GtPyexpp.Where(w => w.BusinessKey == o.BusinessKey && w.PayPeriod == o.PayPeriod).FirstOrDefault();
                        if (pp != null)
                        {
                            if (pp.IsPayrollFreezed)
                                return new DO_ReturnParameter() { Status = false, Message = "Payroll is Freezed. can't make changes." };
                        }

                        GtPyexvi Incentive = db.GtPyexvi.FirstOrDefault(v => v.BusinessKey == obj.BusinessKey && v.PayPeriod == obj.PayPeriod && v.EmployeeNumber == obj.EmployeeNumber);

                        if (Incentive != null)
                        {
                            Incentive.VariableIncentiveAmount = obj.VariableIncentiveAmount;
                            Incentive.ActiveStatus = obj.ActiveStatus;
                            Incentive.ModifiedBy = obj.UserID;
                            Incentive.ModifiedOn = System.DateTime.Now;
                            Incentive.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Incentive Updated Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Incentive." };
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
       
        #endregion Variable Incentive
    }
}
