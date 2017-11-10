using System;

namespace BankKata
{
    public class Transaction
    {
        private readonly DateTime _getTime;
        private readonly IAmount _credit;
        private readonly IAmount _debit;

        public Transaction(DateTime getTime, IAmount credit, IAmount debit)
        {
            _getTime = getTime;
            _credit = credit;
            _debit = debit;
        }

        public override string ToString()
        {
            return $"{_getTime} - credit:{_credit} debit:{_debit}";
        }

        protected bool Equals(Transaction other)
        {
            return _getTime.Equals(other._getTime) && Equals(_credit, other._credit) && Equals(_debit, other._debit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _getTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (_credit != null ? _credit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_debit != null ? _debit.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Transaction left, Transaction right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Transaction left, Transaction right)
        {
            return !Equals(left, right);
        }
    }
}