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
        public void PaymentAcountTransaction(int balance, ushort withdrawAmounMony, ushort putAmounMony, int firstAccountBalance, int secondAccountBalance)
        {
            var clock = new Clock() { Not = new DateTime(2022, 2, 20) };
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var oneTransactionFirstAcount = new PaymentWithdrawBankTransaction(withdrawAmounMony, 10000000, clock.Not, 10000001);
            var oneTransactionSecondAcount = new PaymentToPutBankTransaction(withdrawAmounMony, 10000001, clock.Not);
            var twoTransactionFirstAcount = new PutInAccountTransaction(putAmounMony, 10000000, clock.Not);
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current) { SystemClock = clock };
            var secondAccountBank = new BankAccount(10000001, balance, BankAccountType.Current) { SystemClock = clock };
            //Выполнение операций с картами.
            var isOperation = firstAccountBank.TransferOfMoney(secondAccountBank, withdrawAmounMony);
            firstAccountBank.PutMoney(putAmounMony);
            //Проверка правильности выполнения операций
            Assert.Equal(firstAccountBank.Balance, firstAccountBalance);
            Assert.Equal(secondAccountBank.Balance, secondAccountBalance);
            Assert.NotEmpty(firstAccountBank.Transaction);
            Assert.NotEmpty(secondAccountBank.Transaction);
            Assert.True(NextTransaction(firstAccountBank).Equals(oneTransactionFirstAcount));
            Assert.True(NextTransaction(secondAccountBank).Equals(oneTransactionSecondAcount));
            Assert.True(NextTransaction(firstAccountBank).Equals(twoTransactionFirstAcount));
        }


        private BankTransaction NextTransaction(BankAccount transactions)
        {
            return transactions.Transaction.Dequeue();
        }
    }
}
