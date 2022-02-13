namespace FourthLabWorkInSeventhChapters
{
    public abstract class BankTransaction
    {
        protected readonly DateTime _dateTime;
        protected readonly int _amountOfMony;
        protected readonly int _numberAccountOfTransfer;

        public BankTransaction(int amountOfMony)
        {
            _amountOfMony = amountOfMony;
            _dateTime = DateTime.Now;
        }

        public BankTransaction(int amountOfMony, int numberAccount)
        {
            _amountOfMony = amountOfMony;
            _dateTime = DateTime.Now;
            _numberAccountOfTransfer = numberAccount;
        }

        public abstract string ToString();
    }
}
