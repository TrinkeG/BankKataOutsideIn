using System;

namespace BankKata
{
    public class ATM
    {
        private readonly IStatementPrinter _statementPrinter;
        private readonly ITransactionLedger _transactionLedger;

        public ATM(IStatementPrinter statementPrinter, ITransactionLedger transactionLedger)
        {
            _statementPrinter = statementPrinter;
            _transactionLedger = transactionLedger;
        }

        public void Deposit(int funds)
        {
            Amount depositAmount = new Amount(funds);
            _transactionLedger.Deposit(depositAmount);
        }

        public void Withdraw(int funds)
        {
            Amount depositAmount = new Amount(funds);
            _transactionLedger.Withdraw(depositAmount);
        }

        public void PrintStatement()
        {
            _statementPrinter.Print(_transactionLedger);
        }
    }
}