using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    [Collection("Unit")]
    public class AccountTransfer_Test
    {
        private static void Setup(out Account account1, out Account account2, out AccountDeposit deposit, out AccountTransfer transfer)
        {
            account1 = new Account();
            account2 = new Account();
            deposit = new AccountDeposit(account1);
            transfer = new AccountTransfer(account1);
        }

        private static void TestBaseWithdraw(Account account1, Account account2)
        {
            Assert.Equal(80M, account1.Balance);
            Assert.Equal(20.05M, account2.Balance);

            Assert.Equal(2, account1.Transactions.Count);
            Assert.Single(account2.Transactions);
        }

        [Fact]
        public void Test()
        {
            Account account1, account2;
            AccountDeposit deposit;
            AccountTransfer transfer;
            Setup(out account1, out account2, out deposit, out transfer);

            deposit.Deposit(100.05M);
            transfer.Transfer(20.05M, account2);
            
            TestBaseWithdraw(account1, account2);

            Assert.Equal(DateTime.Today, account1.Transactions[1].Date);
            Assert.Equal(DateTime.Today, account2.Transactions[0].Date);
        }

        [Fact]
        public void TestMockDate()
        {
            Account account1, account2;
            AccountDeposit deposit;
            AccountTransfer transfer;
            Setup(out account1, out account2, out deposit, out transfer);

            deposit.Deposit(100.05M, DateHelper.Get("20/01/2022"));
            transfer.Transfer(20.05M, account2, DateHelper.Get("21/01/2022"));

            TestBaseWithdraw(account1, account2);

            Assert.Equal(DateHelper.Get("21/01/2022"), account1.Transactions[1].Date);
            Assert.Equal(DateHelper.Get("21/01/2022"), account2.Transactions[0].Date);
        }
    }
}
