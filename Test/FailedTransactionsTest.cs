using FourthLabWorkInSeventhChapters;
using Xunit;

namespace Test
{
    public class FailedTransactionsTest
    {
        [Theory]
        [InlineData(1000, 1200, 0, 1000, 1000)]
        public void No_transaction_after_invalid_operation(int balance, ushort withdrawAmounMoney, ushort putAmounMoney, int firstAccountBalance, int secondAccountBalance)
        {
            var balanceAcount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balanceAcount, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balanceAcount, BankAccountType.Current);
            //Выполнение операций с картами.
            var isFirstOperation = firstAccountBank.TransferTo(secondAccountBank, new Money(withdrawAmounMoney));
            firstAccountBank.Put(new Money(putAmounMoney));
            var isSecondOperation = secondAccountBank.Withdraw(new Money(withdrawAmounMoney));
            secondAccountBank.Put(new Money(putAmounMoney));
            //Проверка правильности выполнения операций
            Assert.Equal(new Money(firstAccountBalance), firstAccountBank.Balance);
            Assert.Equal(new Money(secondAccountBalance), secondAccountBank.Balance);
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }
    }
}
