using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BranchAccountRepo
{
    public class BranchAccountRepo : IBranchAccontRepository
    {
        public void Delete(BranchAccount account)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public BranchAccount GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public IList<BranchAccount> GetAccounts()
        => BranchAccountDAO.GetAccounts();

        public BranchAccount Login(string email, string password)
        
            => BranchAccountDAO.Login(email, password);
        

        public void Save(BranchAccount account)
        {
            throw new NotImplementedException();
        }

        public IList<BranchAccount> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(BranchAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
