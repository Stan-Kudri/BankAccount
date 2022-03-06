using FourthLabWorkInSeventhChapters;
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
            var transaction = new WithdrawalsFromAccountTransaction(new Money(amount), 10000000, clock.Now);
            var firstAccountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Current, clock);
            Assert.True(firstAccountBank.Withdraw(new Money(amount)));
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(new Money(accountAmount), firstAccountBank.Balance);
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
