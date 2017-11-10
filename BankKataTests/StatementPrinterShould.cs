using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class StatementPrinterShould
    {
        [Test]
        public void write_header_to_console()
        {
            var mockOutputConsole = new Mock<OutputConsole>();
            
            var statementPrinter = new StatementPrinter(mockOutputConsole.Object);
            var transactionLedger = new Mock<ITransactionLedger>();
            statementPrinter.Print(transactionLedger.Object);
            
            mockOutputConsole.Verify(console => console.WriteLine("date || credit || debit || balance"));
        }
        
    }
}