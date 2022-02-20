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
        public void WithdrawAccountMony(int balance, int amounMony, int accountAmount)
        {
            var transaction = new WithdrawalsFromAccountTransaction(amounMony, 10000000);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current);
            firstAccountBank.WithdrawMoney((ushort)amounMony);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.True(bankTransactionAccount.Equals(transaction));

        }
    }
}
