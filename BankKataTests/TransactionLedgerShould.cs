using System;
using System.Linq;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class TransactionLedgerShould
    {
        [Test]
        public void record_a_deposit_transaction()
        {
            var timeOfTransaction = new DateTime(2017,06,24);
            var clock = new Mock<IClock>();
            clock.Setup(clockMock => clockMock.getTime()).Returns(timeOfTransaction.ToUniversalTime);

            IAmount credit = new Amount(5);
            IAmount debit = new NullAmount();
            var expectedTransaction = new Transaction(clock.Object.getTime(),credit, debit);
            var transactionLedger = new TransactionLedger(clock.Object);
            
            
            transactionLedger.Deposit(credit);

            Assert.AreEqual(expectedTransaction, transactionLedger.GetTransactions().First());
//            Assert.Contains(expectedTransaction,transactionLedger.GetTransactions());
        }
        
    }
}