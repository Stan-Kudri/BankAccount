namespace FourthLabWorkInSeventhChapters
{
    public abstract class BankTransaction : IEquatable<BankTransaction>
    {
        protected readonly DateTime _dateTime;
        protected readonly int _amountOfMony;
        protected readonly int _numberAccount;

        public BankTransaction(int amountOfMony, int numberAccount)
        {
            _amountOfMony = amountOfMony;
            _dateTime = DateTime.Now;
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
            return other._numberAccount == _numberAccount && other._amountOfMony == _amountOfMony && other.GetType() == GetType();
        }

        public abstract override string ToString();

        public override int GetHashCode()
        {
            return _amountOfMony.GetHashCode() * _numberAccount.GetHashCode();
        }
    }
}
