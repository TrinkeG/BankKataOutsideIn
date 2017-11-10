namespace BankKata
{
    public interface ITransactionLedger
    {
        void Deposit(Amount depositAmount);
    }
}