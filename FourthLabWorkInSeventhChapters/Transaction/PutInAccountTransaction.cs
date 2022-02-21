namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PutInAccountTransaction : BankTransaction
    {
        public PutInAccountTransaction(int amountOfMoney, int numberAccount, DateTime dateTime) : base(amountOfMoney, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Пополнение {_numberAccount} счета на сумму {_amountOfMoney}: {_dateTime}");
        }
    }
}
