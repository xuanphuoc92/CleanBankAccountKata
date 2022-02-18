using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    public interface StatementOutputBoundary
    {
        void AcquireStatement(StatementOutputData outputData);
    }
}
