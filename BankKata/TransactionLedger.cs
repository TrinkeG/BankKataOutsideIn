using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankKata
{
    public class TransactionLedger : ITransactionLedger
    {
        private readonly IClock _clock;
        private readonly List<Transaction> _transactions;

        public TransactionLedger(IClock clock)
        {
            _clock = clock;
            _transactions = new List<Transaction>();
        }

        public void Deposit(Amount depositAmount)
        {
            var transaction = new Transaction(_clock.getTime(), depositAmount, new NullAmount());
            StoreTransaction(transaction);
        }

        public void Withdraw(Amount withdrawalAmount)
        {
            var transaction = new Transaction(_clock.getTime(), new NullAmount(), withdrawalAmount);
            StoreTransaction(transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }

        private void StoreTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}