using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    public class AccountTransfer_Test
    {
        [Fact]
        public void Test()
        {
            Account account1 = new Account();
            Account account2 = new Account();
            AccountDeposit deposit = new AccountDeposit(account1);
            AccountTransfer transfer = new AccountTransfer(account1);

            deposit.Deposit(100.05M);
            transfer.Transfer(20.05M, account2);

            Assert.Equal(80M, account1.Balance);
            Assert.Equal(20.05M, account2.Balance);

            Assert.Equal(2, account1.Transactions.Count);
            Assert.Single(account2.Transactions);
        }
    }
}
