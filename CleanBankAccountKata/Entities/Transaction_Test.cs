using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Entities
{
    [Collection("Entity")]
    public class Transaction_Test
    {
        [Fact]
        public void Test()
        {
            Transaction transaction = new Transaction();
            Assert.Null(transaction.Account);
            Assert.Equal(0, transaction.Amount);
            Assert.Equal(0, transaction.Balance);
        }
    }
}
