using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Interactors
{
    [Serializable]
    public class StatementOutputData
    {
        public int AccountId { get; set; }
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();

        public class LineItem
        {
            public DateTime Date { get; set; }
            public decimal? Credit { get; set; }
            public decimal? Debit { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
