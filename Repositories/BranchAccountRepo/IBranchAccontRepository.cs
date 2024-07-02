using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BranchAccountRepo
{
    public interface IBranchAccontRepository
    {
        BranchAccount Login(string email, string password);
        void Save(BranchAccount account);
        void Delete(BranchAccount account);
        void Update(BranchAccount account);
        IList<BranchAccount> GetAccounts();
        BranchAccount GetAccount(int id);
        bool Exist(int id);
        IList<BranchAccount> SearchByName(string name);
    }
}
