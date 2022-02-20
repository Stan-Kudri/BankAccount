using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using System;
using Xunit;

namespace Test
{
    public class PutMoneyTest
    {
        [Theory]
        [InlineData(1000, 200, 1200)]
        [InlineData(1000, 500, 1500)]
        public void PutAccountMony(int balance, ushort amounMony, int accountAmount)
        {
            var clock = new Clock() { Not = new DateTime(2022, 2, 20) };
            var transaction = new PutInAccountTransaction(amounMony, 10000000, clock.Not);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Saving) { SystemClock = clock };
            firstAccountBank.PutMoney(amounMony);
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.True(bankTransactionAccount.Equals(transaction));
        }
    }
}
