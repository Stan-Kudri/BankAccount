﻿using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class PutMoneyTest
    {
        [Theory]
        [InlineData(1000, 200, 1200)]
        [InlineData(1000, 500, 1500)]
        public void Put_in_money_of_bank_account(int balance, Money amount, ushort accountAmount)
        {
            var clock = new TestClock();
            var transaction = new PutInAccountTransaction(amount, 10000000, clock.Now);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Saving, clock);
            firstAccountBank.PutMoney(accountAmount);
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Money, amount);
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
