using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class WithdrawalsFromAccountTest

    {
        [Theory]
        [InlineData(1000, 200, 800)]
        [InlineData(1000, 1000, 0)]
        public void Withdraw_money_of_bank_account(int balance, ushort amounMoney, int accountAmount)
        {
            var clock = new TestClock();
            var transaction = new WithdrawalsFromAccountTransaction(amounMoney, 10000000, clock.Now);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current, clock);
            Assert.True(firstAccountBank.WithdrawMoney(amounMoney));
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
