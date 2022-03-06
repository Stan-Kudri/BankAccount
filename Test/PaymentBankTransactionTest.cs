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
        public void Make_payment_transaction_of_bank_account(int balance, ushort withdrawAmounMoney, ushort putAmounMoney, int firstAccountBalance, int secondAccountBalance)
        {
            var clock = new TestClock();
            var balanceAccount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var oneTransactionFirstAcount = new PaymentWithdrawBankTransaction(new Money(withdrawAmounMoney), 10000000, clock.Now, 10000001);
            var oneTransactionSecondAcount = new PaymentToPutBankTransaction(new Money(withdrawAmounMoney), 10000001, clock.Now);
            var twoTransactionFirstAcount = new PutInAccountTransaction(new Money(putAmounMoney), 10000000, clock.Now);
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Current, clock);
            var secondAccountBank = new BankAccount(10000001, balanceAccount, BankAccountType.Current, clock);
            //Выполнение операций с картами.
            firstAccountBank.TransferOfMoney(secondAccountBank, new Money(withdrawAmounMoney));
            firstAccountBank.Put(new Money(putAmounMoney));
            //Проверка правильности выполнения операций
            //Проверка баланса
            Assert.Equal(new Money(firstAccountBalance), firstAccountBank.Balance);
            Assert.Equal(new Money(secondAccountBalance), secondAccountBank.Balance);
            //Проверка количества прошедших транзакций
            var countTransactionOperationFirstAccount = 2;
            Assert.Equal(countTransactionOperationFirstAccount, firstAccountBank.Transaction.Count);
            Assert.Single(secondAccountBank.Transaction);
            //Проверка прошедших транзакций для первого счета
            Assert.Equal(oneTransactionFirstAcount, NextTransaction(firstAccountBank));
            Assert.Equal(twoTransactionFirstAcount, NextTransaction(firstAccountBank));
            //Проверка прошедших транзакций для второго счета
            Assert.Equal(oneTransactionSecondAcount, NextTransaction(secondAccountBank));
        }

        private BankTransaction NextTransaction(BankAccount transactions)
        {
            return transactions.Transaction.Dequeue();
        }
    }
}
