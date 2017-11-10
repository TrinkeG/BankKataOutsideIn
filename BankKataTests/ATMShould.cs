using System.Runtime.InteropServices.WindowsRuntime;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class ATMShould
    {

        [Test]
        public void deposit_an_amount()
        {
            var depositValue = 5;
            var amount = new Amount(depositValue);
            var statementPrinter = new Mock<IStatementPrinter>();
            var mockTransactionLedger = new Mock<ITransactionLedger>();
            var atm = new ATM(statementPrinter.Object, mockTransactionLedger.Object);
            
            atm.Deposit(5);
            
            mockTransactionLedger.Verify(transactionLedger => transactionLedger.Deposit(amount));
        }
    }
}