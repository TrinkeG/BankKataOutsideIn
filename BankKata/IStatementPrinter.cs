namespace BankKata
{
    public interface IStatementPrinter
    {
        void Print(ITransactionLedger mockTransactionLedger);
    }
}