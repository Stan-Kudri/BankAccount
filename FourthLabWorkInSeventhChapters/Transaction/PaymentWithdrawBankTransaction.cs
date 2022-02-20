namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentWithdrawBankTransaction : BankTransaction
    {
        public readonly int _numberAccountOfTransfer;

        public PaymentWithdrawBankTransaction(int amountOfMony, int numberAccount, DateTime dateTime, int numberAccountOfTransfer) : base(amountOfMony, numberAccount, dateTime)
        {
            _numberAccountOfTransfer = numberAccountOfTransfer;
        }

        public override string ToString()
        {
            return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_amountOfMony} рублей : {DateTime}");
        }
    }
}
