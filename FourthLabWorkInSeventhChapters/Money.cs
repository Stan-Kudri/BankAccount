namespace FourthLabWorkInSeventhChapters
{
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly int _amount;

        public Money(int money)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException("Деньги не могут быть отрицательны!");
            _amount = money;
        }

        public Money Sum(Money amount)
        {
            return new Money(_amount + amount._amount); ;
        }

        public Money Substruct(Money amount)
        {
            if (CompareTo(amount) < 0)
                throw new ArgumentException("Для выполнения операции нет денег!");
            return new Money(_amount - amount._amount);
        }

        public bool Equals(Money? other)
        {
            return other != null && other._amount == _amount;
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
            if (other == null)
                return 1;
            return _amount - other._amount;
        }
    }
}
