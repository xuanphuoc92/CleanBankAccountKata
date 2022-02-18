using CleanBankAccountKata.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Frontend
{
    class StringStatementController
    {
        public StringStatementPresenter RequestStatement(StatementInputData input)
        {
            StatementInputBoundary inputBoundary = StatementInputBoundary.Get();
            var presenter = new StringStatementPresenter();
            inputBoundary.RequestStatement(new StatementInputData() { AccountId = 1 }, presenter);
            return presenter;
        }
    }
}
