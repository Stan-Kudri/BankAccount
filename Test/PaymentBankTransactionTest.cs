using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using System;
using Xunit;

namespace Test
{
    public class PaymentBankTransactionTest
    {
        [Theory]
        [InlineData(1000, 200, 500, 1300, 1200)]
        [InlineData(1000, 1000, 400, 400, 2000)]
        public void PaymentAcountTransaction(int balance, ushort withdrawAmounMoney, ushort putAmounMoney, int firstAccountBalance, int secondAccountBalance)
        {
            var clock = new TestClock();
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var oneTransactionFirstAcount = new PaymentWithdrawBankTransaction(withdrawAmounMoney, 10000000, clock.Now, 10000001);
            var oneTransactionSecondAcount = new PaymentToPutBankTransaction(withdrawAmounMoney, 10000001, clock.Now);
            var twoTransactionFirstAcount = new PutInAccountTransaction(putAmounMoney, 10000000, clock.Now);
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current, clock);
            var secondAccountBank = new BankAccount(10000001, balance, BankAccountType.Current, clock);
            //Выполнение операций с картами.
            firstAccountBank.TransferOfMoney(secondAccountBank, withdrawAmounMoney);
            firstAccountBank.PutMoney(putAmounMoney);
            //Проверка правильности выполнения операций
            Assert.Equal(firstAccountBank.Balance, firstAccountBalance);
            Assert.Equal(secondAccountBank.Balance, secondAccountBalance);
            var countTransactionOperationFirstAccount = 2;
            Assert.Equal(countTransactionOperationFirstAccount, firstAccountBank.Transaction.Count);
            Assert.NotEmpty(secondAccountBank.Transaction);
            Assert.Equal(oneTransactionFirstAcount, NextTransaction(firstAccountBank));
            Assert.Equal(oneTransactionSecondAcount, NextTransaction(secondAccountBank));
            Assert.Equal(twoTransactionFirstAcount, NextTransaction(firstAccountBank));
        }

        public class TestClock : ISystemClock
        {
            public DateTime Now { get; set; } = new DateTime(2022, 2, 20);
        }

        private BankTransaction NextTransaction(BankAccount transactions)
        {
            return transactions.Transaction.Dequeue();
        }
    }
}
