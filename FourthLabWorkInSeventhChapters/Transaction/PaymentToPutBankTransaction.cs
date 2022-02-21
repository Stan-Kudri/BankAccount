namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentToPutBankTransaction : BankTransaction
    {
        public PaymentToPutBankTransaction(int amountOfMoney, int numberAccount, DateTime dateTime) : base(amountOfMoney, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Получение {_amountOfMoney} рублей с карты {_numberAccount}: {_dateTime}");
        }
    }
}
