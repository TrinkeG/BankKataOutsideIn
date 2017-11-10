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
        private static DateTime _timeOfTransaction;
        private static Mock<IClock> _clock;

        [SetUp]
        public void SetUp()
        {
            _timeOfTransaction = new DateTime(2017, 06, 24);
            _clock = new Mock<IClock>();
            _clock.Setup(clockMock => clockMock.getTime()).Returns(_timeOfTransaction.ToUniversalTime);
        }

        [Test]
        public void record_a_deposit_transaction()
        {
            var credit = new Amount(5);
            IAmount debit = new NullAmount();
            var expectedTransaction = new Transaction(_clock.Object.getTime(),credit, debit);
            var transactionLedger = new TransactionLedger(_clock.Object);
            
            transactionLedger.Deposit(credit);

            Assert.Contains(expectedTransaction,transactionLedger.GetTransactions());
        }

        [Test]
        public void record_a_withdrawal_transaction()
        {
            var debit = new Amount(5);
            IAmount credit = new NullAmount();
            var expectedTransaction = new Transaction(_clock.Object.getTime(),credit, debit);
            var transactionLedger = new TransactionLedger(_clock.Object);
            
            transactionLedger.Withdraw(debit);

            Assert.Contains(expectedTransaction,transactionLedger.GetTransactions());
        }
    }
}