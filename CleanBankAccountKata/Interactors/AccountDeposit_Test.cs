using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    public class AccountDeposit_Test
    {
        [Fact]
        public void Test()
        {
            Account account = new Account();
            AccountDeposit deposit = new AccountDeposit(account);

            Assert.Equal(0, account.Balance);
            deposit.Deposit(100);
            Assert.Equal(100, account.Balance);
        }
    }
}
