using FourthLabWorkInSeventhChapters;
using Xunit;

namespace Test
{
    public class FailedTransactionsTest
    {
        [Theory]
        [InlineData(1000, 1200, 0, 1000, 1000)]
        public void FieldAcountTransaction(int balance, int withdrawAmounMony, int putAmounMony, int firstAccountBalance, int secondAccountBalance)
        {
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balance, BankAccountType.Current);
            //Выполнение операций с картами.
            var isFirstOperation = firstAccountBank.TransferOfMoney(secondAccountBank, (ushort)withdrawAmounMony);
            firstAccountBank.PutMoney((ushort)putAmounMony);
            var isSecondOperation = secondAccountBank.WithdrawMoney((ushort)withdrawAmounMony);
            secondAccountBank.PutMoney((ushort)putAmounMony);
            //Проверка правильности выполнения операций
            Assert.Equal(firstAccountBank.Balance, firstAccountBalance);
            Assert.Equal(secondAccountBank.Balance, secondAccountBalance);
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            Assert.True(firstAccountBank.Transaction.Count == 0);
            Assert.True(secondAccountBank.Transaction.Count == 0);
        }
    }
}
