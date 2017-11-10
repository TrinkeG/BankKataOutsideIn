using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankKata
{
    public class TransactionLedger : ITransactionLedger
    {
        private readonly IClock _clock;
        private List<Transaction> _transactions;

        public TransactionLedger(IClock clock)
        {
            _clock = clock;
            _transactions = new List<Transaction>();
        }

        public void Deposit(IAmount depositAmount)
        {
            var transaction = new Transaction(_clock.getTime(), depositAmount, new NullAmount());
            _transactions.Add(transaction);
        }

        public void Withdraw(Amount amount)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}