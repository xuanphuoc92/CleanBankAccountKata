using CleanBankAccountKata.Interactors;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanBankAccountKata.Frontend
{
    public class StringStatement_Test
    {
        [Fact]
        public void Test()
        {
            Statement_Test.SetupAccountForStatementTest();

            StringStatementController controller = new StringStatementController();
            StringStatementPresenter presenter = controller.RequestStatement(new StatementInputData() { AccountId = 1 });

            StringBuilder expectedPrint = new StringBuilder();

            expectedPrint.AppendLine("Account: 1");
            expectedPrint.AppendLine("Date || Credit || Debit || Balance");
            expectedPrint.AppendLine("20/01/2022 || 100.00 ||  || 100.00");
            expectedPrint.AppendLine("21/01/2022 ||  || 20.00 || 80.00");

            Assert.Equal(expectedPrint.ToString(), presenter.Print());
        }
    }
}
