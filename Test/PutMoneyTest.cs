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
            var transaction = new PutInAccountTransaction(new Money(amount), 10000000, clock.Now);
            var firstAccountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Saving, clock);
            firstAccountBank.Put(new Money(amount));
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(new Money(accountAmount), firstAccountBank.Balance);
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
