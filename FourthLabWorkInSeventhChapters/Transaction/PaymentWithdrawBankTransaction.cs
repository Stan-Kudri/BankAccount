namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentWithdrawBankTransaction : BankTransaction
    {
        public readonly int _numberAccountOfTransfer;

        public PaymentWithdrawBankTransaction(int amountOfMoney, int numberAccount, DateTime dateTime, int numberAccountOfTransfer) : base(amountOfMoney, numberAccount, dateTime)
        {
            _numberAccountOfTransfer = numberAccountOfTransfer;
        }

        public override string ToString()
        {
            return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_amountOfMoney} рублей : {_dateTime}");
        }
    }
}
