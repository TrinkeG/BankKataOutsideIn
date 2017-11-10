using System;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter
    {
            private readonly OutputConsole _outputConsole;

            public StatementPrinter(OutputConsole outputConsole)
            {
                _outputConsole = outputConsole;
            }

            public void Print()
            {
                const string header = "date || credit || debit || balance";
                _outputConsole.WriteLine(header);
            }
        }
}