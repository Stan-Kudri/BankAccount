namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentWithdrawBankTransaction : BankTransaction
    {
        public readonly int _numberAccountOfTransfer;

        public PaymentWithdrawBankTransaction(int amountOfMony, int numberAccount, int numberAccountOfTransfer) : base(amountOfMony, numberAccount)
        {
            _numberAccountOfTransfer = numberAccountOfTransfer;
        }

        public override string ToString()
        {
            return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_amountOfMony} рублей : {_dateTime}");
        }
    }
}
