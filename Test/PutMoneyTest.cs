using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class PutMoneyTest
    {
        [Theory]
        [InlineData(1000, 10000000, 200, 1200)]
        [InlineData(1000, 10000000, 500, 1500)]
        [InlineData(1000, 10000000, 0, 1000)]
        public void PutAccountMony(int balance, int numberAccount, int amounMony, int accountAmount)
        {
            var firstAccountBank = new BankAccount(numberAccount, balance, BankAccountType.Saving);
            firstAccountBank.PutMoney((ushort)amounMony);
            var transaction = new PutInAccountTransaction(amounMony, 10000000);
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.True(firstAccountBank.Transaction.Peek().Equals(transaction));
        }
    }
}
