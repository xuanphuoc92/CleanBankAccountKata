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
            Assert.Empty(account.Transactions);
            deposit.Deposit(100.05M);
            Assert.Equal(100.05M, account.Balance);
            Assert.Single(account.Transactions);
            
            Transaction transaction;
            transaction = account.Transactions[0];
            Assert.Equal(account, transaction.Account);
            Assert.Equal(100.05M, transaction.Amount);
            Assert.Equal(100.05M, transaction.Balance);
        }
    }
}
