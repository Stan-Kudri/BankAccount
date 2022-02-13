namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentWithdrawBankTransaction : BankTransaction
    {
        public PaymentWithdrawBankTransaction(int amountOfMony) : base(amountOfMony)
        {
        }

        public PaymentWithdrawBankTransaction(int amountOfMony, int numberAccount) : base(amountOfMony, numberAccount)
        {
        }

        public override string ToString()
        {
            return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_amountOfMony} рублей : {_dateTime}");
        }
    }
}
