using CleanBankAccountKata.DataInterfaces;
using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    class Statement : StatementInputBoundary
    {
        public StatementOutputData GetStatementOutputData(StatementInputData input)
        {
            Account account = AccountContext.Get().Load(input.AccountId);
            StatementOutputData output = new StatementOutputData();
            output.AccountId = account.Id;
            foreach (Transaction transaction in account.Transactions)
                output.LineItems.Add(new StatementOutputData.LineItem() {
                    Date = transaction.Date,
                    Credit = (transaction.Amount > 0 ? (decimal?)transaction.Amount : null),
                    Debit = (transaction.Amount < 0 ? (decimal?)transaction.Amount * -1 : null),
                    Balance = transaction.Balance
                });
            return output;
        }
    }
}
