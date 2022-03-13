namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentWithdrawBankTransaction : BankTransaction
    {
        public readonly NumberBankAccount _numberAccountOfTransfer;

        public PaymentWithdrawBankTransaction(Money amount, NumberBankAccount numberAccount, DateTime dateTime, NumberBankAccount numberAccountOfTransfer) : base(amount, numberAccount, dateTime)
        {
            _numberAccountOfTransfer = numberAccountOfTransfer;
        }

        public override string ToString()
        {
            return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_money} рублей : {_dateTime}");
        }
    }
}
