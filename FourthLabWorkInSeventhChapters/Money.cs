namespace FourthLabWorkInSeventhChapters
{
    public class Money : IEquatable<Money>, IComparer<Money>
    {
        private readonly int _balance;

        public Money(int money)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException("Деньги не могут быть отрицательны!");
            _balance = money;
        }

        public Money Put(Money amount)
        {
            return new Money(_balance + amount._balance);
        }

        public Money Withdraw(Money amount)
        {
            if (_balance < amount._balance)
                throw new ArgumentException("Для выполнения операции нет денег!");
            return new Money(_balance - amount._balance);
        }

        public bool Equals(Money? other)
        {
            if (other == null)
                throw new ArgumentNullException("NULL!!!");
            return other._balance == _balance;
        }

        public override int GetHashCode()
        {
            return _balance.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"{_balance}");
        }

        public int Compare(Money? x, Money? y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("NULL!!!");
            return x._balance - y._balance;
        }
    }
}
