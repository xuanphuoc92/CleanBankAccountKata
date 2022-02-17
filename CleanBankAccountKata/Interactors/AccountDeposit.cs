using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    class AccountDeposit
    {
        private Account account;

        public AccountDeposit(Account account)
        {
            this.account = account;
        }

        internal void Deposit(decimal amount)
        {
            account.Balance += amount;
        }
    }
}
