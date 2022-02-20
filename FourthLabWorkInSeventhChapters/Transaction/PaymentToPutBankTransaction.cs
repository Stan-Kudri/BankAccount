namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentToPutBankTransaction : BankTransaction
    {
        public PaymentToPutBankTransaction(int amountOfMony, int numberAccount, DateTime dateTime) : base(amountOfMony, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Получение {_amountOfMony} рублей с карты {_numberAccount}: {DateTime}");
        }
    }
}
