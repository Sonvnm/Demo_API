using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BranchAccountDAO
    {
        // alo
        public static BranchAccount Login(string email, string password)
        {
            using var context = new SilverJewelry2024DBContext();
            return context.BranchAccounts.SingleOrDefault(c => c.EmailAddress == email && c.AccountPassword == password);
        }
        public static IList<BranchAccount> GetAccounts()
        {
            var list = new List<BranchAccount>();

            try
            {
                using var context = new SilverJewelry2024DBContext();
                list = context.BranchAccounts.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list;
        }

    }
}
