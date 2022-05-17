namespace Bank.Domain
{
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly int _amount;

        public bool IsZero => _amount == 0;

        public Money(int money)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException("Деньги не могут быть отрицательны!");
            _amount = money;
        }

        public static Money operator +(Money? left, Money? right)
        {
            ArgumentNullException.ThrowIfNull(left, nameof(left));
            ArgumentNullException.ThrowIfNull(right, nameof(right));
            return new Money(left._amount + right._amount);
        }

        public static Money operator -(Money? left, Money? right)
        {
            ArgumentNullException.ThrowIfNull(left, nameof(left));
            ArgumentNullException.ThrowIfNull(right, nameof(right));

            if (left < right)
                throw new InvalidOperationException("Значение левой части меньше правой.");

            return new Money(left._amount - right._amount);
        }

        public static bool operator >(Money? left, Money? right)
        {
            if (ReferenceEquals(left, null))
                return false;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(Money? left, Money? right)
        {
            if (ReferenceEquals(right, null))
                return false;
            return right.CompareTo(left) > 0;
        }

        public static bool operator ==(Money? left, Money? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        public static bool operator !=(Money? left, Money? right)
        {
            return !(left == right);
        }

        public static bool operator >=(Money? left, Money? right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <=(Money? left, Money? right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.CompareTo(right) <= 0;
        }

        public bool Equals(Money? other)
        {
            return !ReferenceEquals(other, null) && other._amount == _amount;
        }

        public override int GetHashCode()
        {
            return _amount.GetHashCode();
        }

        public override string ToString()
        {
            return _amount.ToString();
        }

        public int CompareTo(Money? other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            return _amount - other._amount;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Money);
        }
    }
}
