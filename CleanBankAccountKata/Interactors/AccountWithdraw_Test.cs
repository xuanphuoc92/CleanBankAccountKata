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
            Assert.Empty(account.Transactions);
            deposit.Deposit(100.05M);
            Assert.Equal(100.05M, account.Balance);
            Assert.Single(account.Transactions);

            withdraw.Withdraw(20.05M);
            Assert.Equal(80, account.Balance);
            Assert.Equal(2, account.Transactions.Count);

            Assert.Equal(DateTime.Today, account.Transactions[1].Date);
        }

        [Fact]
        public void TestMockDate()
        {
            Account account = new Account();
            AccountDeposit deposit = new AccountDeposit(account);
            AccountWithdraw withdraw = new AccountWithdraw(account);

            deposit.Deposit(100.05M, DateHelper.Get("20/01/2022"));
            Assert.Equal(100.05M, account.Balance);
            Assert.Single(account.Transactions);

            withdraw.Withdraw(20.05M, DateHelper.Get("21/01/2022"));
            Assert.Equal(80, account.Balance);
            Assert.Equal(2, account.Transactions.Count);

            Assert.Equal(DateHelper.Get("21/01/2022"), account.Transactions[1].Date);
        }
    }
}
