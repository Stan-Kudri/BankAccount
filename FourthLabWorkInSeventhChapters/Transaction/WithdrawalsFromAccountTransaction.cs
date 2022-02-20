namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class WithdrawalsFromAccountTransaction : BankTransaction
    {
        public WithdrawalsFromAccountTransaction(int amountOfMony, int numberAccount, DateTime dateTime) : base(amountOfMony, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Списание со счета {_numberAccount} суммы {_amountOfMony}: {DateTime}");
        }
    }
}
