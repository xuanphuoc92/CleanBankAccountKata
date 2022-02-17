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

        internal void Transfer(decimal amount, Account other)
        {
            AccountWithdraw withdraw = new AccountWithdraw(account);
            AccountDeposit deposit = new AccountDeposit(other);

            withdraw.Withdraw(amount);
            deposit.Deposit(amount);
        }
    }
}
