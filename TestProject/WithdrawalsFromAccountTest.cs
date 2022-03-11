using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace TestProject
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
            var accountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Saving, clock);
            //Выполнение операций с картами.
            var isFirstOperation = accountBank.Withdraw(new Money(amount));

            //Создание правильной транзакции для сравнения и происходящей транзакции.
            var transaction = new WithdrawalsFromAccountTransaction(new Money(amount), 10000000, clock.Now);
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
