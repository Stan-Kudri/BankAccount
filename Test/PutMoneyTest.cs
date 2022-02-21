﻿using FourthLabWorkInSeventhChapters;
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
        public void PutAccountMony(int balance, ushort amounMoney, int accountAmount)
        {
            var clock = new TestClock();
            var transaction = new PutInAccountTransaction(amounMoney, 10000000, clock.Now);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Saving, clock);
            firstAccountBank.PutMoney(amounMoney);
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.Equal(transaction, bankTransactionAccount);
        }

        public class TestClock : ISystemClock
        {
            public DateTime Now { get; set; } = new DateTime(2022, 2, 20);
        }
    }
}
