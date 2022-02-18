using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.DataInterfaces
{
    class AccountContext
    {
        private IDataAccess<Account, int> dataAccess = DataAccessFactory<Account, int>.Get(account => account.Id);

        internal int Count => dataAccess.Count;
        internal void Save(Account account)
        {
            if (account.Id == 0)
                account.Id = Count + 1;
            dataAccess.Save(account);
        }
        internal Account Load(int id) => dataAccess.Load(id);

        private AccountContext() { }
        private static AccountContext context = new AccountContext();
        public static AccountContext Get() => context;
        public static void Reset()
        {
            context = new AccountContext();
        }
    }
}
