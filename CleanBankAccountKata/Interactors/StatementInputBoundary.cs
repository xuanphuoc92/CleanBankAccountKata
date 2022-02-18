using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    public interface StatementInputBoundary
    {
        void RequestStatement(StatementInputData inputData, StatementOutputBoundary outputBoundary);

        public static StatementInputBoundary Get() => new Statement();
    }
}
