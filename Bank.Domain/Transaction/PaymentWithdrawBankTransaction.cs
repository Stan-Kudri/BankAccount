namespace Bank.Domain.Transaction
{
    public class PaymentWithdrawBankTransaction : BankTransaction
    {
        public readonly int _numberAccountOfTransfer;

        public PaymentWithdrawBankTransaction(Money amount, int numberAccount, DateTime dateTime, int numberAccountOfTransfer) : base(amount, numberAccount, dateTime)
        {
            _numberAccountOfTransfer = numberAccountOfTransfer;
        }

        public override string ToString()
        {
            return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_money} рублей : {_dateTime}");
        }
    }
}
