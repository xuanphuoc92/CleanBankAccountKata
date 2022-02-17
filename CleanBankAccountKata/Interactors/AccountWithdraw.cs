using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    class AccountWithdraw
    {
        private Account account;

        public AccountWithdraw(Account account)
        {
            this.account = account;
        }

        internal void Withdraw(decimal amount)
        {
            account.Balance -= amount;
        }
    }
}
