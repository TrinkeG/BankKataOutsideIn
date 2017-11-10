using System.Runtime.InteropServices.WindowsRuntime;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class ATMShould
    {
        private Mock<IStatementPrinter> _statementPrinter;
        private Mock<ITransactionLedger> _mockTransactionLedger;
        private ATM _atm;

        [SetUp]
        public void Setup()
        {
            _statementPrinter = new Mock<IStatementPrinter>();
            _mockTransactionLedger = new Mock<ITransactionLedger>();
            _atm = new ATM(_statementPrinter.Object, _mockTransactionLedger.Object);
        }
        

        [Test]
        public void Deposit_an_amount()
        {
            var depositValue = 5;
            var amount = new Amount(depositValue);
            
            
            _atm.Deposit(5);
            
            _mockTransactionLedger.Verify(transactionLedger => transactionLedger.Deposit(amount));
        }
        
        [Test]
        public void Withdraw_an_amount()
        {
            var withdrawalAmount = 5;
            var amount = new Amount(withdrawalAmount);
            
            _atm.Withdraw(5);
            
            _mockTransactionLedger.Verify(transactionLedger => transactionLedger.Withdraw(amount));
        }

        [Test]
        public void Print_a_statement()
        {
            
            _atm.PrintStatement();
            
            _statementPrinter.Verify(statementPrinter => statementPrinter.Print(It.IsAny<ITransactionLedger>()));
        }
        
        

    }
}