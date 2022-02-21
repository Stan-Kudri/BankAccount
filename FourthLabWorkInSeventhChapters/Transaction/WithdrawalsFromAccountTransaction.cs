namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class WithdrawalsFromAccountTransaction : BankTransaction
    {
        public WithdrawalsFromAccountTransaction(int amountOfMoney, int numberAccount, DateTime dateTime) : base(amountOfMoney, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Списание со счета {_numberAccount} суммы {_amountOfMoney}: {_dateTime}");
        }
    }
}
