using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.DataInterfaces
{
    public class AccountContext_Test
    {
        [Fact]
        public void Test()
        {
            Account account = new Account();
            account.Transact(100.05M);
            account.Transact(-20M);
            Assert.Equal(0, account.Id);
            Assert.Equal(80.05M, account.Balance);
            Assert.Equal(2, account.Transactions.Count);

            AccountContext.Reset();
            AccountContext context = AccountContext.Get();
            Assert.Equal(0, context.Count);

            context.Save(account);
            Assert.Equal(1, account.Id);
            Assert.Equal(80.05M, account.Balance);
            Assert.Equal(2, account.Transactions.Count);

            Account loadedAccount = context.Load(1);
            Assert.Equal(1, loadedAccount.Id);
            Assert.Equal(80.05M, loadedAccount.Balance);
            Assert.Equal(2, loadedAccount.Transactions.Count);
        }
    }
}
