using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class WithdrawalsFromAccountTest

    {
        [Theory]
        [InlineData(1000, 200, 800, true)]
        [InlineData(1000, 1000, 0, true)]
        [InlineData(1000, 1200, 1000, false)]
        public void WithdrawAccountMony(int balance, int amounMony, int accountAmount, bool availabilityOfTransactions)
        {
            var firstAccountBank = new BankAccount(balance);
            var transaction = new WithdrawalsFromAccountTransaction(amounMony, firstAccountBank.NumberAccount);
            Assert.Equal(availabilityOfTransactions, firstAccountBank.WithdrawMoney((ushort)amounMony));
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            if (availabilityOfTransactions == true)
                Assert.True(firstAccountBank.Transaction.Peek().Equals(transaction));
        }
    }
}
