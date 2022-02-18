using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    class AccountTransfer
    {
        private Account account;

        public AccountTransfer(Account account)
        {
            this.account = account;
        }

        internal void Transfer(decimal amount, Account other, DateTime? date = null)
        {
            AccountWithdraw withdraw = new AccountWithdraw(account);
            AccountDeposit deposit = new AccountDeposit(other);

            withdraw.Withdraw(amount, date);
            deposit.Deposit(amount, date);
        }
    }
}
