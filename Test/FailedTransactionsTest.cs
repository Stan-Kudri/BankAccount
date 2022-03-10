using FourthLabWorkInSeventhChapters;
using Xunit;

namespace Test
{
    public class FailedTransactionsTest
    {
        [Theory]
        [InlineData(1000, 1200)]
        public void Transfer_more_money_than_available(int balance, ushort withdrawAmounMoney)
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
            Assert.Equal(new Money(balance), firstAccountBank.Balance);
            Assert.Equal(new Money(balance), secondAccountBank.Balance);
            //Проверка выполнения транзакции, если денег для перевода (перевода денег с одного счета на другой) или снятия определенного количества денег не достаточно.
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            //Проверка на нулевое значение транзакций.
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000)]
        public void Transfer_zero_money_impossible(int balance)
        {
            var balanceAcount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.

            //Создание банковских счетов с определенным балансом из входных данных.
            var firstAccountBank = new BankAccount(10000000, balanceAcount, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balanceAcount, BankAccountType.Current);

            //Выполнение операции по переводу 0 денег на счет.
            var operation = firstAccountBank.TransferTo(secondAccountBank, new Money(0));

            //Проверка правильности выполнения операций
            //Проверка значения баланса счета
            Assert.Equal(new Money(balance), firstAccountBank.Balance);
            Assert.Equal(new Money(balance), secondAccountBank.Balance);
            //Проверка выполнения транзакции при переводе 0 денег.
            Assert.False(operation);
            //Проверка на нулевое значение транзакций.
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000)]
        public void Put_zero_money_impossible(int balance)
        {
            var balanceAcount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.

            //Создание банковских счетов с определенным балансом из входных данных.
            var AccountBank = new BankAccount(10000000, balanceAcount, BankAccountType.Current);

            //Выполнение операции по переводу 0 денег на счет.
            var operation = AccountBank.Put(new Money(0));

            //Проверка правильности выполнения операций
            //Проверка значения баланса счета
            Assert.Equal(new Money(balance), AccountBank.Balance);
            //Проверка выполнения транзакции при пополнении счета на 0 денег.
            Assert.False(operation);
            //Проверка на нулевое значение транзакций.
            Assert.Empty(AccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000)]
        public void Withdrawals_zero_money_impossible(int balance)
        {
            var balanceAcount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.

            //Создание банковских счетов с определенным балансом из входных данных.
            var AccountBank = new BankAccount(10000000, balanceAcount, BankAccountType.Current);

            //Выполнение операции по переводу 0 денег на счет.
            var operation = AccountBank.Withdraw(new Money(0));

            //Проверка правильности выполнения операций
            //Проверка значения баланса счета
            Assert.Equal(new Money(balance), AccountBank.Balance);
            //Проверка выполнения транзакции при снятии со счета 0 денег.
            Assert.False(operation);
            //Проверка на нулевое значение транзакций.
            Assert.Empty(AccountBank.Transaction);
        }
    }
}
