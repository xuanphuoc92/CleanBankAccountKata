using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.DataInterfaces
{
    class AccountContext
    {
        private MemoryDataAccess dataAccess = new MemoryDataAccess();

        internal int Count => dataAccess.Count;
        internal void Save(Account account) => dataAccess.Save(account);
        internal Account Load(int id) => dataAccess.Load(id);
    }
}
