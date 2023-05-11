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
    public class PayrollProcessRepository : IPayrollProcessRepository
    {
        public async Task<List<DO_Currency>> GetCurrencyExchangeRate(int businessKey, int payPeriod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEccuco
                        .GroupJoin(db.GtIfcrer.Where(w => w.BusinessKey == businessKey),
                        c => c.CurrencyCode,
                        e => e.CurrencyCode,
                        (c, e) => new { c, e = e.FirstOrDefault() }).DefaultIfEmpty()
                        .Where(w => w.c.ActiveStatus)
                        .Select(
                            x => new DO_Currency
                            {
                                CurrencyCode = x.c.CurrencyCode,
                                ExchangeRate = x.e != null ? (decimal)x.e.StandardRate : 1
                            }).ToListAsync();

                    var ce = ds.GroupJoin(db.GtPyexce.Where(w => w.BusinessKey == businessKey && w.PayPeriod == payPeriod),
                            c => c.CurrencyCode,
                            e => e.CurrencyCode,
                            (c, e) => new { c, e = e.FirstOrDefault() }).DefaultIfEmpty()
                          .Select(
                            x => new DO_Currency
                            {
                                CurrencyCode = x.c.CurrencyCode,
                                ExchangeRate = x.e != null ? (decimal)x.e.ExchangeRate : x.c.ExchangeRate
                            }).ToList();

                    return ce;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_PayrollProcess>> GetEmployeeForPayrollProcess(int businessKey, int payPeriod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ps = await db.GtPyexta
                        .Join(db.GtPyexem,
                            a => new { a.BusinessKey, a.EmployeeNumber },
                            e => new { e.BusinessKey, e.EmployeeNumber },
                            (a, e) => new { a, e })
                         .Join(db.GtPyexsi,
                            ae => new { ae.a.BusinessKey, ae.a.EmployeeNumber },
                            s => new { s.BusinessKey, s.EmployeeNumber },
                            (ae, s) => new { ae, s })
                       .GroupJoin(db.GtPyexva.Where(w => w.ActiveStatus),
                            aes => new { aes.ae.a.BusinessKey, aes.ae.a.EmployeeNumber, aes.ae.a.PayPeriod },
                            v => new { v.BusinessKey, v.EmployeeNumber, v.PayPeriod },
                            (aes, v) => new { aes, v = v.FirstOrDefault() }).DefaultIfEmpty()
                        .Where(w => w.aes.ae.a.BusinessKey == businessKey
                                    && w.aes.ae.a.PayPeriod == payPeriod
                                    && !db.GtPyexps.Any(s => s.BusinessKey == w.aes.ae.a.BusinessKey
                                            && s.PayPeriod == w.aes.ae.a.PayPeriod && s.EmployeeNumber == w.aes.ae.a.EmployeeNumber))
                        .Select(
                            x => new DO_PayrollProcess
                            {
                                EmployeeNumber = x.aes.ae.e.EmployeeNumber,
                                EmployeeName = x.aes.ae.e.Title + " " + x.aes.ae.e.EmployeeName,
                                SalaryAmount = x.aes.s.SalaryAmount,
                                SalaryCurrency = x.aes.s.SalaryCurrency,
                                AttendanceFactor = x.aes.ae.a.AttendanceFactor,
                                IsIncentiveApplicable = x.aes.s.IsIncentiveApplicable,
                                IsBankChargeApplicable = x.aes.s.IsBankChargeApplicable,
                                IsVacationPay = x.aes.ae.a.IsVacationPay,
                                AdvanceAmount = x.v != null ? x.v.SalaryAdvance : 0,
                                NHIFAmount = x.aes.s.Nhifamount,
                                NSSFAmount = x.aes.s.Nssfamount,
                                PayrollStatus = "S"
                            }).OrderBy(o => o.EmployeeName).ToListAsync();

                    var vi = db.GtPyexvi.Where(w => w.BusinessKey == businessKey && w.PayPeriod == payPeriod);
                    foreach (var i in vi)
                    {
                        var p = ps.Where(w => w.EmployeeNumber == i.EmployeeNumber).FirstOrDefault();
                        if (p != null)
                        {
                            p.VariableIncentiveAmount = i.VariableIncentiveAmount;
                        }
                    }

                    return ps;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_PayrollProcess>> GetPayrollProcessedEmployee(int businessKey, int payPeriod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtPyexps
                        .Join(db.GtPyexem,
                            p => new { p.BusinessKey, p.EmployeeNumber },
                            e => new { e.BusinessKey, e.EmployeeNumber },
                            (p, e) => new { p, e })
                        .Where(w => w.p.BusinessKey == businessKey && w.p.PayPeriod == payPeriod)
                        .Select(
                            x => new DO_PayrollProcess
                            {
                                EmployeeNumber = x.e.EmployeeNumber,
                                EmployeeName = x.e.EmployeeName,
                                SalaryCurrency = x.p.SalaryCurrency,
                                SalaryAmount = x.p.SalaryAmount,
                                AttendanceFactor = x.p.AttendanceFactor,
                                IsVacationPay = x.p.IsVacationPay,
                                ProcessedAmount = x.p.ProcessedAmount,
                                ExchangeRate = x.p.ExchangeRate,
                                AmountInLocalCurrency = x.p.AmountInLocalCurrency,
                                VariableIncentiveAmount = x.p.VariableIncentiveAmount,
                                AdvanceAmount = x.p.AdvanceAmount,
                                NetSalaryAmount = x.p.NetSalaryAmount,
                                NHIFAmount = x.p.Nhifamount,
                                NSSFAmount = x.p.Nssfamount,
                                PayrollStatus = "P"
                            }).OrderBy(o => o.EmployeeName).ToListAsync();
                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_PayrollProcess>> GetEmployeeForPayrollProcess_Redo(int businessKey, int payPeriod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ps = await db.GtPyexta
                        .Join(db.GtPyexem,
                            a => new { a.BusinessKey, a.EmployeeNumber },
                            e => new { e.BusinessKey, e.EmployeeNumber },
                            (a, e) => new { a, e })
                         .Join(db.GtPyexsi,
                            ae => new { ae.a.BusinessKey, ae.a.EmployeeNumber },
                            s => new { s.BusinessKey, s.EmployeeNumber },
                            (ae, s) => new { ae, s })
                        .Where(w => w.ae.a.BusinessKey == businessKey
                                    && w.ae.a.PayPeriod == payPeriod
                                    && db.GtPyexps.Any(s => s.BusinessKey == w.ae.a.BusinessKey
                                            && s.PayPeriod == w.ae.a.PayPeriod && s.EmployeeNumber == w.ae.a.EmployeeNumber))
                        .Select(
                            x => new DO_PayrollProcess
                            {
                                EmployeeNumber = x.ae.e.EmployeeNumber,
                                EmployeeName = x.ae.e.Title + " " + x.ae.e.EmployeeName,
                                SalaryAmount = x.s.SalaryAmount,
                                SalaryCurrency = x.s.SalaryCurrency,
                                AttendanceFactor = x.ae.a.AttendanceFactor,
                                IsIncentiveApplicable = x.s.IsIncentiveApplicable,
                                IsBankChargeApplicable = x.s.IsBankChargeApplicable,
                                IsVacationPay = x.ae.a.IsVacationPay,
                                AdvanceAmount = 0,
                                NHIFAmount = x.s.Nhifamount,
                                NSSFAmount = x.s.Nssfamount,
                                PayrollStatus = "S"
                            }).OrderBy(o => o.EmployeeName).ToListAsync();

                    var ad = db.GtPyexva.Where(w => w.BusinessKey == businessKey && w.PayPeriod == payPeriod && w.ActiveStatus);
                    foreach (var i in ad)
                    {
                        var p = ps.Where(w => w.EmployeeNumber == i.EmployeeNumber).FirstOrDefault();
                        if (p != null)
                        {
                            p.AdvanceAmount = i.SalaryAdvance;
                        }
                    }

                    var vi = db.GtPyexvi.Where(w => w.BusinessKey == businessKey && w.PayPeriod == payPeriod && w.ActiveStatus);
                    foreach (var i in vi)
                    {
                        var p = ps.Where(w => w.EmployeeNumber == i.EmployeeNumber).FirstOrDefault();
                        if (p != null)
                        {
                            p.VariableIncentiveAmount = i.VariableIncentiveAmount;
                        }
                    }

                    //var payroll_proccessed = await GetPayrollProcessedEmployee(businessKey, payPeriod);

                    //var r_ps = ps.Join(payroll_proccessed,
                    //            s => new { s.BusinessKey, s.PayPeriod, s.EmployeeNumber },
                    //            p => new { p.BusinessKey, p.PayPeriod, p.EmployeeNumber },
                    //            (s, p) => new { s, p })
                    //            .Where(w => w.s.AttendanceFactor != w.p.AttendanceFactor)
                    //            .Select(x => new DO_PayrollProcess
                    //            {
                    //                EmployeeNumber = x.s.EmployeeNumber,
                    //                EmployeeName = x.s.EmployeeName,
                    //                SalaryAmount = x.s.SalaryAmount,
                    //                SalaryCurrency = x.s.SalaryCurrency,
                    //                AttendanceFactor = x.s.AttendanceFactor,
                    //                IsIncentiveApplicable = x.s.IsIncentiveApplicable,
                    //                IsBankChargeApplicable = x.s.IsBankChargeApplicable,
                    //                IsVacationPay = x.s.IsVacationPay,
                    //                AdvanceAmount = x.s.AdvanceAmount,
                    //                VariableIncentiveAmount = x.s.VariableIncentiveAmount,
                    //                NHIFAmount = x.s.NHIFAmount,
                    //                NSSFAmount = x.s.NSSFAmount,
                    //                PayrollStatus = "S"
                    //            });

                    return ps;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<DO_ReturnParameter> InsertIntoPayrollProcess(List<DO_PayrollProcess> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var op = obj.FirstOrDefault();
                        var pp = db.GtPyexpp.Where(w => w.BusinessKey == op.BusinessKey && w.PayPeriod == op.PayPeriod).FirstOrDefault();
                        if (pp != null)
                        {
                            if (pp.IsPayrollFreezed)
                                return new DO_ReturnParameter() { Status = false, Message = "Payroll is Freezed. can't make changes." };
                        }

                        if (obj.Count > 0)
                        {
                            foreach (var c in obj[0].l_Currency)
                            {
                                var ce = await db.GtPyexce.Where(w => w.BusinessKey == op.BusinessKey
                                               && w.PayPeriod == op.PayPeriod && w.CurrencyCode == c.CurrencyCode).FirstOrDefaultAsync();
                                if (ce == null)
                                {
                                    ce = new GtPyexce
                                    {
                                        BusinessKey = obj[0].BusinessKey,
                                        PayPeriod = obj[0].PayPeriod,
                                        CurrencyCode = c.CurrencyCode,
                                        ExchangeRate = c.ExchangeRate,
                                        ActiveStatus = true,
                                        FormId = obj[0].FormId,
                                        CreatedBy = obj[0].UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj[0].TerminalID
                                    };

                                    db.GtPyexce.Add(ce);
                                }
                                else
                                {
                                    ce.ExchangeRate = c.ExchangeRate;
                                    ce.ModifiedBy = obj[0].UserID;
                                    ce.ModifiedOn = System.DateTime.Now;
                                    ce.ModifiedTerminal = obj[0].TerminalID;
                                }
                                await db.SaveChangesAsync();
                            }
                        }

                        foreach (var s in obj)
                        {
                            var ps_exists = db.GtPyexpb.Where(w => w.BusinessKey == op.BusinessKey
                                                && w.PayPeriod == op.PayPeriod
                                                && w.EmployeeNumber == s.EmployeeNumber
                                                && w.OrgBankCode != null).FirstOrDefault();
                            if (ps_exists != null)
                            {
                                if (ps_exists.OrgBankDate != null)
                                    return new DO_ReturnParameter() { Status = false, Message = "Salary payment for the employee is done on " + ps_exists.OrgBankDate.Value.ToString("dd-MMM-yy") };
                            }

                            var del_ps = db.GtPyexps.Where(w => w.BusinessKey == op.BusinessKey
                                            && w.PayPeriod == op.PayPeriod
                                            && w.EmployeeNumber == s.EmployeeNumber);
                            db.GtPyexps.RemoveRange(del_ps);

                            var del_pb = db.GtPyexpb.Where(w => w.BusinessKey == op.BusinessKey
                                          && w.PayPeriod == op.PayPeriod
                                          && w.EmployeeNumber == s.EmployeeNumber);
                            db.GtPyexpb.RemoveRange(del_pb);

                            db.SaveChanges();



                            GtPyexps ps = new GtPyexps
                            {
                                BusinessKey = s.BusinessKey,
                                EmployeeNumber = s.EmployeeNumber,
                                PayPeriod = s.PayPeriod,
                                ProcessedDate = System.DateTime.Now,
                                SalaryCurrency = s.SalaryCurrency,
                                SalaryAmount = s.SalaryAmount,
                                AttendanceFactor = s.AttendanceFactor,
                                ProcessedAmount = s.ProcessedAmount,
                                IsVacationPay = s.IsVacationPay,
                                ExchangeRate = s.ExchangeRate,
                                AmountInLocalCurrency = s.AmountInLocalCurrency,
                                VariableIncentiveAmount = s.VariableIncentiveAmount,
                                AdvanceAmount = s.AdvanceAmount,
                                Bcdebit = false,
                                BankCharges = 0,
                                NetSalaryAmount = s.NetSalaryAmount,
                                Nhifamount = s.NHIFAmount,
                                Nssfamount = s.NSSFAmount,
                                ActiveStatus = true,
                                FormId = s.FormId,
                                CreatedBy = s.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = s.TerminalID
                            };
                            await db.GtPyexps.AddAsync(ps);

                            var localCurrency = db.GtEcbsln
                                .Join(db.GtEcbssg,
                                    l => new { l.BusinessId, l.SegmentId },
                                    b => new { b.BusinessId, b.SegmentId },
                                    (l, b) => new { l, b })
                               .Where(w => w.l.BusinessKey == s.BusinessKey).FirstOrDefault().b.CurrencyCode;


                            var l_sb = db.GtPyexsb.Where(w => w.BusinessKey == s.BusinessKey && w.EmployeeNumber == s.EmployeeNumber
                                        && w.PaymentByCurrency == localCurrency).OrderByDescending(o => o.TransferTo);
                            var t_sb = db.GtPyexsb.Where(w => w.BusinessKey == s.BusinessKey && w.EmployeeNumber == s.EmployeeNumber
                                        && w.PaymentByCurrency != localCurrency).OrderByDescending(o => o.TransferTo);
                            var sb = l_sb.Union(t_sb);

                            var i = 0;
                            var totalCount = sb.Count();
                            var totalSalaryPerct = 0;
                            decimal reminingSalaryAmount = s.NetSalaryAmount;
                            decimal remainingAdvanceAmount = s.AdvanceAmount;

                            //var l_ex = obj.Select(e => new DO_Currency
                            //{
                            //    CurrencyCode = e.SalaryCurrency,
                            //    ExchangeRate = e.ExchangeRate
                            //}).Distinct();
                            var l_ex = s.l_Currency;

                            foreach (var b in sb)
                            {
                                // var salaryPerct = ((b.PaymentAmountBySalaryCurrency * 100) / s.SalaryAmount);
                                // var salaryAmount = s.NetSalaryAmount * salaryPerct / 100;
                                var salaryAmount = b.PaymentAmountBySalaryCurrency * s.ExchangeRate;
                                if (remainingAdvanceAmount > 0)
                                {
                                    if (salaryAmount > remainingAdvanceAmount)
                                    {
                                        salaryAmount = salaryAmount - remainingAdvanceAmount;
                                        remainingAdvanceAmount = 0;
                                    }
                                    else
                                    {
                                        remainingAdvanceAmount -= salaryAmount;
                                        i++;
                                        continue;
                                    }

                                }

                                if (++i == totalCount)
                                {
                                    //  salaryPerct = 100 - totalSalaryPerct;
                                    salaryAmount = reminingSalaryAmount;
                                }
                                reminingSalaryAmount -= salaryAmount;
                                if (reminingSalaryAmount < 0)
                                    break;

                                var exc = l_ex.Where(w => w.CurrencyCode == b.PaymentByCurrency).FirstOrDefault();
                                decimal bankExchangeRate = 1;
                                if (exc != null)
                                    bankExchangeRate = exc.ExchangeRate;

                                GtPyexpb pb = new GtPyexpb();
                                pb.BusinessKey = s.BusinessKey;
                                pb.EmployeeNumber = s.EmployeeNumber;
                                pb.PayPeriod = s.PayPeriod;
                                pb.SerialNumber = i;
                                pb.BankRemittance = b.TransferTo;
                                pb.BankCurrency = b.PaymentByCurrency;
                                pb.ExchangeRate = bankExchangeRate;//s.ExchangeRate;
                                pb.SalaryCurrencyAmount = salaryAmount / bankExchangeRate;//s.ExchangeRate;
                                pb.LocalCurrencyAmount = salaryAmount;
                                if (pb.BankRemittance == "B")
                                {
                                    var bankDetail = await db.GtPyexbd.Where(w => w.BusinessKey == s.BusinessKey && w.EmployeeNumber == s.EmployeeNumber
                                                        && w.BankCurrency == pb.BankCurrency).FirstOrDefaultAsync();
                                    if (bankDetail != null)
                                    {
                                        pb.AccountHolderName = bankDetail.AccountHolderName;
                                        pb.AccountNumber = bankDetail.AccountNumber;
                                        pb.BankCode = bankDetail.BankCode;
                                        pb.BankName = bankDetail.BankName;
                                        pb.BranchCode = bankDetail.BranchCode;
                                        pb.BranchName = bankDetail.BranchName;
                                        pb.BankAddress = bankDetail.BankAddress;
                                        pb.BeneficiaryAddress = bankDetail.BeneficiaryAddress;
                                        pb.Ifsccode = bankDetail.Ifsccode;
                                        pb.Swiftcode = bankDetail.Swiftcode;
                                        pb.Iban = bankDetail.Iban;
                                        pb.CorrespondingBankName = bankDetail.CorrespondingBankName;
                                        pb.CorrespondingBankAddress = bankDetail.CorrespondingBankAddress;
                                        pb.CorrespondingBankAccountNumber = bankDetail.CorrespondingBankAccountNumber;
                                    }
                                    else
                                    {
                                        return new DO_ReturnParameter { Status = false, Message = "Bank detail is not provided for employee " + s.EmployeeName };
                                    }
                                }
                                pb.ActiveStatus = true;
                                pb.FormId = s.FormId;
                                pb.CreatedBy = s.UserID;
                                pb.CreatedOn = System.DateTime.Now;
                                pb.CreatedTerminal = s.TerminalID;

                                await db.GtPyexpb.AddAsync(pb);
                            }
                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter { Status = true };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public async Task<List<DO_PayrollProcess>> GetSalaryRegister(int businessKey, int payPeriod)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtPyexps
                        .Join(db.GtPyexem,
                            p => new { p.BusinessKey, p.EmployeeNumber },
                            e => new { e.BusinessKey, e.EmployeeNumber },
                            (p, e) => new { p, e })
                        .Where(w => w.p.BusinessKey == businessKey && w.p.PayPeriod == payPeriod)
                        .Select(
                            x => new DO_PayrollProcess
                            {
                                EmployeeNumber = x.e.EmployeeNumber,
                                EmployeeName = x.e.EmployeeName,
                                SalaryAmount = x.p.SalaryAmount,
                                SalaryCurrency = x.p.SalaryCurrency,
                                AttendanceFactor = x.p.AttendanceFactor,
                                IsVacationPay = x.p.IsVacationPay,
                                ProcessedAmount = x.p.ProcessedAmount,
                                ExchangeRate = x.p.ExchangeRate,
                                AmountInLocalCurrency = x.p.AmountInLocalCurrency,
                                VariableIncentiveAmount = x.p.VariableIncentiveAmount,
                                AdvanceAmount = x.p.AdvanceAmount,
                                NHIFAmount = x.p.Nhifamount,
                                NSSFAmount = x.p.Nssfamount,
                                NetSalaryAmount = x.p.NetSalaryAmount,
                                CashAmount = db.GtPyexpb.Where(c => c.BusinessKey == businessKey && c.PayPeriod == payPeriod
                                                 && c.EmployeeNumber == x.p.EmployeeNumber && c.BankRemittance == "C").Sum(s => s.LocalCurrencyAmount),
                                BankAmount = db.GtPyexpb.Where(c => c.BusinessKey == businessKey && c.PayPeriod == payPeriod
                                                 && c.EmployeeNumber == x.p.EmployeeNumber && c.BankRemittance == "B").Sum(s => s.LocalCurrencyAmount),
                            }).ToListAsync();
                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
