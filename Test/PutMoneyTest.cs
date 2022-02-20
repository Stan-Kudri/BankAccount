using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class PutMoneyTest
    {
        [Theory]
        [InlineData(1000, 200, 1200)]
        [InlineData(1000, 500, 1500)]
        public void PutAccountMony(int balance, int amounMony, int accountAmount)
        {
            var transaction = new PutInAccountTransaction(amounMony, 10000000);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Saving);
            firstAccountBank.PutMoney((ushort)amounMony);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.True(bankTransactionAccount.Equals(transaction));
        }
    }
}
