using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using System;
using Xunit;

namespace Test
{
    public class WithdrawalsFromAccountTest

    {
        [Theory]
        [InlineData(1000, 200, 800)]
        [InlineData(1000, 1000, 0)]
        public void WithdrawAccountMony(int balance, ushort amounMony, int accountAmount)
        {
            var clock = new Clock() { Not = new DateTime(2022, 2, 20) };
            var transaction = new WithdrawalsFromAccountTransaction(amounMony, 10000000, clock.Not);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current) { SystemClock = clock };
            Assert.True(firstAccountBank.WithdrawMoney(amounMony));
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.True(bankTransactionAccount.Equals(transaction));
        }

    }
}
