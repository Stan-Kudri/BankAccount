using FourthLabWorkInSeventhChapters;
using Xunit;

namespace Test
{
    public class FailedTransactionsTest
    {
        [Theory]
        [InlineData(1000, 1200, 1000)]
        public void No_transaction_after_withdraw_money_in_account_or_put_money_another_account(int balance, ushort withdrawAmounMoney, int accountBalance)
        {
            var balanceAcount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.

            //Создание банковских счетов с определенным балансом из входных данных.
            var firstAccountBank = new BankAccount(10000000, balanceAcount, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balanceAcount, BankAccountType.Current);

            //Выполнение операций с картами.
            var isFirstOperation = firstAccountBank.TransferTo(secondAccountBank, new Money(withdrawAmounMoney));
            var isSecondOperation = firstAccountBank.Withdraw(new Money(withdrawAmounMoney));

            //Проверка правильности выполнения операций.
            //Проверка значения баланса счета.
            Assert.Equal(new Money(accountBalance), firstAccountBank.Balance);
            Assert.Equal(new Money(accountBalance), secondAccountBank.Balance);
            //Проверка выполнения транзакции, если денег для перевода (перевода денег с одного счета на другой) или снятия определенного количества денег не достаточно.
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            //Проверка на нулевое значение транзакций.
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000, 1000)]
        public void No_transaction_after_operation_zero_money(int balance, int accountBalance)
        {
            var balanceAcount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.

            //Создание банковских счетов с определенным балансом из входных данных.
            var firstAccountBank = new BankAccount(10000000, balanceAcount, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balanceAcount, BankAccountType.Current);

            //Выполнение операций с картами при взаимодействии с деньгами равными 0.
            var isFirstOperation = firstAccountBank.Put(new Money(0));
            var isSecondOperation = firstAccountBank.Withdraw(new Money(0));
            var isThirdOperation = firstAccountBank.TransferTo(secondAccountBank, new Money(0));

            //Проверка правильности выполнения операций
            //Проверка значения баланса счета
            Assert.Equal(new Money(accountBalance), firstAccountBank.Balance);
            Assert.Equal(new Money(accountBalance), secondAccountBank.Balance);
            //Проверка выполнения транзакции при использовании при транзации денег равных 0.
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            Assert.False(isThirdOperation);
            //Проверка на нулевое значение транзакций.
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }
    }
}
