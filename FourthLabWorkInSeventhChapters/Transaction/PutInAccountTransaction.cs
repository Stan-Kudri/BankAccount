namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PutInAccountTransaction : BankTransaction
    {
        public PutInAccountTransaction(int amountOfMony, int numberAccount, DateTime dateTime) : base(amountOfMony, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Пополнение {_numberAccount} счета на сумму {_amountOfMony}: {DateTime}");
        }
    }
}
