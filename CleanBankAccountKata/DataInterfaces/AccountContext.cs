using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.DataInterfaces
{
    class AccountContext
    {
        private Dictionary<int, Account> keyValues = new Dictionary<int, Account>();

        public int Count => keyValues.Count;

        internal void Save(Account account)
        {
            if (account.Id == 0)
                account.Id = keyValues.Count + 1;
            if (keyValues.ContainsKey(account.Id))
                keyValues[account.Id] = account;
            else
                keyValues.Add(account.Id, account);
        }

        internal Account Load(int id)
        {
            if (keyValues.ContainsKey(id))
                return keyValues[id];
            return null;
        }
    }
}
