namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class ToPutInAccount : BankTransaction
    {
        public ToPutInAccount(int amountOfMony) : base(amountOfMony)
        {
        }

        public ToPutInAccount(int amountOfMony, int numberAccount) : base(amountOfMony, numberAccount)
        {
        }

        public override string ToString()
        {
            return string.Format($"Пополнение счета на сумму {_amountOfMony}: {_dateTime}");
        }
    }
}
