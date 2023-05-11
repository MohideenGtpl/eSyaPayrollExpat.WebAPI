using System;
using System.Linq;
using System.Collections.Generic;
using eSyaPayrollExpat.DL.Entities;
using eSyaPayrollExpat.DO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eSyaPayrollExpat.DL.Repository
{
   public class CommonMethod
    {
        public static string GetValidationMessageFromException(DbUpdateException ex)
        {
            string msg = ex.InnerException == null ? ex.ToString() : ex.InnerException.Message;

            if (msg.LastIndexOf(',') == msg.Length - 1)
                msg = msg.Remove(msg.LastIndexOf(','));
            return msg;
        }
    }
}
