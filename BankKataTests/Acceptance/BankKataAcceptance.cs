using BankKata;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace BankKataTests
{
    [TestFixture]
    public partial class BankKataAcceptance
    {
/*        Given a client makes a deposit of 1000 on 10-01-2012
        And a deposit of 2000 on 13-01-2012
        And a withdrawal of 500 on 14-01-2012
        When she prints her bank statement
        Then she would see
        date || credit || debit || balance
        14/01/2012 || || 500.00 || 2500.00
        13/01/2012 || 2000.00 || || 3000.00
        10/01/2012 || 1000.00 || || 1000.00*/
        [Test]
        public void Acceptance()
        {
            var mockOutputConsole = new Mock<OutputConsole>();
            var statementPrinter = new StatementPrinter(mockOutputConsole.Object);
            var transactionLedger = new Mock<ITransactionLedger>();
            var atm = new ATM(statementPrinter, transactionLedger.Object);
            
            atm.Deposit(1000);
            atm.Deposit(2000);
            atm.Withdraw(500);
            atm.PrintStatement();


            mockOutputConsole.Verify(console => console.WriteLine("date || credit || debit || balance"));
            mockOutputConsole.Verify(outputMock => outputMock.WriteLine("14/01/2012 || || 500.00 || 2500.00"));
            mockOutputConsole.Verify(outputMock => outputMock.WriteLine("13/01/2012 || 2000.00 || || 3000.00"));
            mockOutputConsole.Verify(outputMock => outputMock.WriteLine("10/01/2012 || 1000.00 || || 1000.00"));
        }
    }
}