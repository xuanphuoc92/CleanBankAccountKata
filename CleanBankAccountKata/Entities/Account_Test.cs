using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Entities
{
    public class Account_Test
    {
        [Fact]
        public void Default()
        {
            Account account = new Account();
            Assert.Equal(0, account.Id);
            Assert.Equal(0, account.Balance);
        }
    }
}
