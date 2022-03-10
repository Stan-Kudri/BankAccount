using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class PutMoneyTest
    {
        [Theory]
        [InlineData(1000, 200, 1200)]
        [InlineData(1000, 500, 1500)]
        public void Put_in_money_of_bank_account(int balance, ushort amount, ushort accountAmount)
        {
            var balanceAccount = new Money(balance);
            var clock = new TestClock();
            //Создание банковских счетов с определенным балансом из входных данных.
            var accountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Saving, clock);
            //Выполнение операций с картами.
            var isFirstOperation = accountBank.Put(new Money(amount));

            //Проверка правильности выполнения операций.
            //Создание правильной транзакции для сравнения и происходящей транзакции.
            var transaction = new PutInAccountTransaction(new Money(amount), 10000000, clock.Now);
            var bankTransactionAccount = accountBank.PopLastTransaction();
            //Проверка значения баланса счета.
            Assert.Equal(new Money(accountAmount), accountBank.Balance);
            //Проверка выполнения транзакции, если денег для снятия определенного количества денег достаточно.
            Assert.True(isFirstOperation);
            //Проверка значения транзакции.
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
