using CleanBankAccountKata.DataInterfaces;
using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    class Statement : StatementInputBoundary
    {
        public void RequestStatement(StatementInputData inputData, StatementOutputBoundary outputBoundary)
        {
            var outputData = GetStatementOutputData(inputData);
            outputBoundary.AcquireStatement(outputData);
        }

        internal StatementOutputData GetStatementOutputData(StatementInputData inputData)
        {
            Account account = AccountContext.Get().Load(inputData.AccountId);
            StatementOutputData outputData = new StatementOutputData();
            outputData.AccountId = account.Id;
            foreach (Transaction transaction in account.Transactions)
                outputData.LineItems.Add(new StatementOutputData.LineItem()
                {
                    Date = transaction.Date,
                    Credit = (transaction.Amount > 0 ? (decimal?)transaction.Amount : null),
                    Debit = (transaction.Amount < 0 ? (decimal?)transaction.Amount * -1 : null),
                    Balance = transaction.Balance
                });
            return outputData;
        }
    }
}
