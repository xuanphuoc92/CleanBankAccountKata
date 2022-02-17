using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    public class AccountWithdraw_Test
    {
        [Fact]
        public void Test()
        {
            Account account = new Account();
            AccountDeposit deposit = new AccountDeposit(account);
            AccountWithdraw withdraw = new AccountWithdraw(account);

            Assert.Equal(0, account.Balance);
            deposit.Deposit(100.05M);
            Assert.Equal(100.05M, account.Balance);
            withdraw.Withdraw(20.05M);
            Assert.Equal(80, account.Balance);
        }
    }
}
