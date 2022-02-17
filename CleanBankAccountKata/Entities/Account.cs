using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.Entities
{
    class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public void Transact(decimal amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction()
            {
                Account = this,
                Amount = amount,
                Balance = Balance
            });
        }
    }
}
