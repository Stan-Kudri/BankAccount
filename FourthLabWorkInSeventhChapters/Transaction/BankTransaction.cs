namespace FourthLabWorkInSeventhChapters
{
    public abstract class BankTransaction : IEquatable<BankTransaction>
    {
        protected readonly int _amountOfMoney;
        protected readonly int _numberAccount;

        protected readonly DateTime _dateTime;

        public BankTransaction(int amountOfMoney, int numberAccount, DateTime dateTime)
        {
            _amountOfMoney = amountOfMoney;
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
            return other._dateTime == _dateTime && other._numberAccount == _numberAccount && other._amountOfMoney == _amountOfMoney && other.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_amountOfMoney, _dateTime, _numberAccount, GetType());
        }
    }
}
