namespace Bank.Domain.Transaction
{
    public class PaymentToPutBankTransaction : BankTransaction
    {
        public PaymentToPutBankTransaction(Money amount, int numberAccount, DateTime dateTime) : base(amount, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Получение {_money} рублей с карты {_numberAccount}: {_dateTime}");
        }
    }
}
