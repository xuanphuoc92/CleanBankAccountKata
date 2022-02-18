using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    [Serializable]
    class StatementOutputData
    {
        public int AccountId { get; set; }

        public class LineItems
        {
            public DateTime Date { get; set; }
            public decimal? Credit { get; set; }
            public decimal? Debit { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
