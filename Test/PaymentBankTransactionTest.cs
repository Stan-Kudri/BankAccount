using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class PaymentBankTransactionTest
    {
        [Theory]
        [InlineData(1000, 200, 500, 1300, 1200)]
        [InlineData(1000, 1000, 400, 400, 2000)]
        public void PaymentAcountTransaction(int balance, int withdrawAmounMony, int putAmounMony, int firstAccountBalance, int secondAccountBalance)
        {
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var oneTransactionFirstAcount = new PaymentWithdrawBankTransaction(withdrawAmounMony, 10000000, 10000001);
            var oneTransactionSecondAcount = new PaymentToPutBankTransaction(withdrawAmounMony, 10000001);
            var twoTransaction = new PutInAccountTransaction(putAmounMony, 10000000);
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balance, BankAccountType.Current);
            //Выполнение операций с картами.
            var isOperation = firstAccountBank.TransferOfMoney(secondAccountBank, (ushort)withdrawAmounMony);
            firstAccountBank.PutMoney((ushort)putAmounMony);
            //Проверка правильности выполнения операций
            Assert.Equal(firstAccountBank.Balance, firstAccountBalance);
            Assert.Equal(secondAccountBank.Balance, secondAccountBalance);
            Assert.True(firstAccountBank.Transaction.Dequeue().Equals(oneTransactionFirstAcount));
            Assert.True(secondAccountBank.Transaction.Dequeue().Equals(oneTransactionSecondAcount));
            Assert.True(firstAccountBank.Transaction.Dequeue().Equals(twoTransaction));
        }
    }
}
