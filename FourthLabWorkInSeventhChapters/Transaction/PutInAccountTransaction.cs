namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PutInAccountTransaction : BankTransaction
    {
        public PutInAccountTransaction(int amountOfMony, int numberAccount) : base(amountOfMony, numberAccount)
        {
        }

        public override string ToString()
        {
            return string.Format($"Пополнение {_numberAccount} счета на сумму {_amountOfMony}: {_dateTime}");
        }
    }
}
