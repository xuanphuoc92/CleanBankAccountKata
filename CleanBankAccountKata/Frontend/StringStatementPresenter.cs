using CleanBankAccountKata.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Frontend
{
    class StringStatementPresenter : StatementOutputBoundary
    {
        private StatementOutputData outputData;

        public void AcquireStatement(StatementOutputData outputData)
        {
            this.outputData = outputData;
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Account: {outputData.AccountId}");
            result.AppendLine("Date || Credit || Debit || Balance");
            foreach (var lineItem in outputData.LineItems)
            {
                result.AppendLine($"{lineItem.Date.ToString("dd/MM/yyyy")} || {lineItem.Credit?.ToString("#.00")} || {lineItem.Debit?.ToString("#.00")} || {lineItem.Balance.ToString("#.00")}");
            }

            return result.ToString();
        }
    }
}
