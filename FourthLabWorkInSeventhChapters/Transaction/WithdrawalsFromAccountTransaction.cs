namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class WithdrawalsFromAccountTransaction : BankTransaction
    {
        public WithdrawalsFromAccountTransaction(int amountOfMony, int numberAccount) : base(amountOfMony, numberAccount)
        {
        }

        public override string ToString()
        {
            return string.Format($"Списание со счета {_numberAccount} суммы {_amountOfMony}: {_dateTime}");
        }
    }
}
