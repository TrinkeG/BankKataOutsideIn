namespace BankKata
{
    public class NullAmount : IAmount
    {
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(NullAmount);
        }
    }
}