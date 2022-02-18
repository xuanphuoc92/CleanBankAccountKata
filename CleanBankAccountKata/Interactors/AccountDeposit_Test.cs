using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    public class AccountDeposit_Test
    {
        private static void TestSetup(out Account account, out AccountDeposit deposit)
        {
            account = new Account();
            deposit = new AccountDeposit(account);
            Assert.Equal(0, account.Balance);
            Assert.Empty(account.Transactions);
        }

        private static Transaction TestBaseDeposit(Account account)
        {
            Assert.Equal(100.05M, account.Balance);
            Assert.Single(account.Transactions);

            Transaction transaction;
            transaction = account.Transactions[0];
            Assert.Equal(account, transaction.Account);
            Assert.Equal(100.05M, transaction.Amount);
            Assert.Equal(100.05M, transaction.Balance);
            return transaction;
        }

        [Fact]
        public void Test()
        {
            Account account;
            AccountDeposit deposit;
            TestSetup(out account, out deposit);

            deposit.Deposit(100.05M);

            Transaction transaction = TestBaseDeposit(account);

            Assert.Equal(DateTime.Today, transaction.Date);
        }

        [Fact]
        public void TestMockDate()
        {
            Account account;
            AccountDeposit deposit;
            TestSetup(out account, out deposit);

            deposit.Deposit(100.05M, DateHelper.Get("20/01/2022"));

            Assert.Equal(100.05M, account.Balance);
            Assert.Single(account.Transactions);

            Transaction transaction = TestBaseDeposit(account);

            Assert.Equal(DateHelper.Get("20/01/2022"), transaction.Date);
        }
    }
}
