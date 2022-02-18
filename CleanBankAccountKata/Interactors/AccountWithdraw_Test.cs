using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    [Collection("Unit")]
    public class AccountWithdraw_Test
    {
        private static void TestBaseWithdrawal(Account account)
        {
            Assert.Equal(80, account.Balance);
            Assert.Equal(2, account.Transactions.Count);
        }

        [Fact]
        public void Test()
        {
            Account account = new Account();
            AccountDeposit deposit = new AccountDeposit(account);
            AccountWithdraw withdraw = new AccountWithdraw(account);

            deposit.Deposit(100.05M);
            withdraw.Withdraw(20.05M);

            TestBaseWithdrawal(account);
            Assert.Equal(DateTime.Today, account.Transactions[1].Date);
        }

        [Fact]
        public void TestMockDate()
        {
            Account account = new Account();
            AccountDeposit deposit = new AccountDeposit(account);
            AccountWithdraw withdraw = new AccountWithdraw(account);

            deposit.Deposit(100.05M, DateHelper.Get("20/01/2022"));
            withdraw.Withdraw(20.05M, DateHelper.Get("21/01/2022"));

            TestBaseWithdrawal(account);
            Assert.Equal(DateHelper.Get("21/01/2022"), account.Transactions[1].Date);
        }
    }
}
