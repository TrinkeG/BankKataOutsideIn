namespace BankKata
{
    public interface ITransactionLedger
    {
        void Deposit(IAmount depositAmount);
        void Withdraw(Amount amount);
    }
}