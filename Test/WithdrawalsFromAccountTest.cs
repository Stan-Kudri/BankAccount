﻿using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class WithdrawalsFromAccountTest

    {
        [Theory]
        [InlineData(1000, 200, 800)]
        [InlineData(1000, 1000, 0)]
        public void Withdraw_money_of_bank_account(int balance, ushort amount, int accountAmount)
        {
            var clock = new TestClock();
            var balanceAccount = new Money(balance);
            //Создание банковских счетов с определенным балансом из входных данных.
            var firstAccountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Saving, clock);
            //Выполнение операций с картами.
            var isFirstOperation = firstAccountBank.Withdraw(new Money(amount));

            //Проверка правильности выполнения операций.
            //Создание правильной транзакции для сравнения и происходящей транзакции.
            var transaction = new WithdrawalsFromAccountTransaction(new Money(amount), 10000000, clock.Now);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            //Проверка значения баланса счета.
            Assert.Equal(new Money(accountAmount), firstAccountBank.Balance);
            //Проверка выполнения транзакции, если денег для снятия определенного количества денег достаточно.
            Assert.True(isFirstOperation);
            //Проверка значения транзакции.
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
