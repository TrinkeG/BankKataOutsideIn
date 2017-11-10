namespace BankKata
{
    public class Amount : IAmount
    {
        private readonly int _value;

        public Amount(int value)
        {
            _value = value;
        }

        public override bool Equals(object obj)
        {
            var compareTo = (Amount) obj;
            return _value==compareTo._value;
        }
    }
}