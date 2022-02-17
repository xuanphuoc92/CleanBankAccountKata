using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Entities
{
    class Transaction
    {
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
    }
}
