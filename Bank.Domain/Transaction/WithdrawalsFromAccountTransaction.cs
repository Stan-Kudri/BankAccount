namespace Bank.Domain.Transaction
{
    public class WithdrawalsFromAccountTransaction : BankTransaction
    {
        public WithdrawalsFromAccountTransaction(Money amount, int numberAccount, DateTime dateTime) : base(amount, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Списание со счета {_numberAccount} суммы {_money}: {_dateTime}");
        }
    }
}
