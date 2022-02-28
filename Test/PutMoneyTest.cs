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
        public void Put_in_money_of_bank_account(int balance, ushort amounMoney, int accountAmount)
        {
            var clock = new TestClock();
            var transaction = new PutInAccountTransaction(amounMoney, 10000000, clock.Now);
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Saving, clock);
            firstAccountBank.PutMoney(amounMoney);
            Assert.Single(firstAccountBank.Transaction);
            var bankTransactionAccount = firstAccountBank.Transaction.Peek();
            Assert.Equal(firstAccountBank.Balance, accountAmount);
            Assert.Equal(transaction, bankTransactionAccount);
        }
    }
}
