namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class WithdrawalsFromAccount : BankTransaction
    {
        public WithdrawalsFromAccount(int amountOfMony) : base(amountOfMony)
        {
        }

        public WithdrawalsFromAccount(int amountOfMony, int numberAccount) : base(amountOfMony, numberAccount)
        {
        }

        public override string ToString()
        {
            return string.Format($"Списание со счета суммы {_amountOfMony}: {_dateTime}");
        }
    }
}
