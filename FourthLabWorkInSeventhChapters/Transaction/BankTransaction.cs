namespace FourthLabWorkInSeventhChapters
{
    public abstract class BankTransaction : IEquatable<BankTransaction>
    {
        protected readonly int _amountOfMony;
        protected readonly int _numberAccount;

        public DateTime DateTime { get; private set; }

        public BankTransaction(int amountOfMony, int numberAccount, DateTime dateTime)
        {
            _amountOfMony = amountOfMony;
            DateTime = dateTime;
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
            return other.DateTime == DateTime && other._numberAccount == _numberAccount && other._amountOfMony == _amountOfMony && other.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_amountOfMony, DateTime, _numberAccount);
        }
    }
}
