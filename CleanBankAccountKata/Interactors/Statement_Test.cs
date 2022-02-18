using CleanBankAccountKata.DataInterfaces;
using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Interactors
{
    public class Statement_Test
    {
        public static void SetupAccountForStatementTest()
        {
            AccountContext.Reset();

            Account account = new Account();
            AccountDeposit deposit = new AccountDeposit(account);
            AccountWithdraw withdraw = new AccountWithdraw(account);

            deposit.Deposit(100, DateHelper.Get("20/01/2022"));
            withdraw.Withdraw(20, DateHelper.Get("21/01/2022"));

            AccountContext.Get().Save(account);
        }

        [Fact]
        public void Test()
        {
            SetupAccountForStatementTest();

            Statement statement = new Statement();
            var outputData = statement.GetStatementOutputData(new StatementInputData() { AccountId = 1 });

            Assert.Equal(1, outputData.AccountId);
            Assert.Equal(2, outputData.LineItems.Count);

            AssertLineItem(outputData.LineItems[0], DateHelper.Get("20/01/2022"), 100, null, 100);
            AssertLineItem(outputData.LineItems[1], DateHelper.Get("21/01/2022"), null, 20, 80);
        }

        private void AssertLineItem(StatementOutputData.LineItem lineItem, DateTime date, decimal? credit, decimal? debit, decimal balance)
        {
            Assert.Equal(date, lineItem.Date);
            Assert.Equal(credit, lineItem.Credit);
            Assert.Equal(debit, lineItem.Debit);
            Assert.Equal(balance, lineItem.Balance);
        }
    }
}
