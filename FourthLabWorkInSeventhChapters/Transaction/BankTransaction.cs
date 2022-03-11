namespace FourthLabWorkInSeventhChapters
{
    public abstract class BankTransaction : IEquatable<BankTransaction>
    {
        protected readonly int _numberAccount;
        protected readonly Money _money;

        protected readonly DateTime _dateTime;

        public BankTransaction(Money amount, int numberAccount, DateTime dateTime)
        {
            _money = amount;
            _dateTime = dateTime;
            _numberAccount = numberAccount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is BankTransaction transaction)
                return Equals(transaction);
            return false;
        }

        public bool Equals(BankTransaction? other)
        {
            if (other == null)
                return false;
            return other._dateTime == _dateTime && other._numberAccount == _numberAccount && other._money.Equals(_money) && other.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_money, _dateTime, _numberAccount, GetType());
        }
    }
}
