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
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var oneTransactionFirstAcount = new PaymentWithdrawBankTransaction(withdrawAmounMoney, 10000000, clock.Now, 10000001);
            var oneTransactionSecondAcount = new PaymentToPutBankTransaction(withdrawAmounMoney, 10000001, clock.Now);
            var twoTransactionFirstAcount = new PutInAccountTransaction(putAmounMoney, 10000000, clock.Now);
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current, clock);
            var secondAccountBank = new BankAccount(10000001, balance, BankAccountType.Current, clock);
            //Выполнение операций с картами.
            firstAccountBank.TransferOfMoney(secondAccountBank, withdrawAmounMoney);
            firstAccountBank.PutMoney(putAmounMoney);
            //Проверка правильности выполнения операций
            //Проверка баланса
            Assert.Equal(firstAccountBank.Balance, firstAccountBalance);
            Assert.Equal(secondAccountBank.Balance, secondAccountBalance);
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
