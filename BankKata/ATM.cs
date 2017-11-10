namespace BankKata
{
    public class ATM
    {
        private readonly StatementPrinter _statementPrinter;

        public ATM(StatementPrinter statementPrinter)
        {
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int funds)
        {
        }

        public void Withdraw(int funds)
        {
        }

        public void PrintStatement()
        {
        }
    }
}