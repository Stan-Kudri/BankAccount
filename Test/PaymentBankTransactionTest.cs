using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace Test
{
    public class PaymentBankTransactionTest
    {
        [Theory]
        [InlineData(1000, 200, 1000)]
        [InlineData(1000, 1000, 1000)]
        public void Make_payment_transaction_of_bank_account(int balance, ushort amountMoney, int accountBalance)
        {
            var clock = new TestClock();
            var balanceAccount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var firstTransactionBankAcount = new WithdrawalsFromAccountTransaction(new Money(amountMoney), 10000000, clock.Now);
            var secondTransactionBankAcount = new PutInAccountTransaction(new Money(amountMoney), 10000001, clock.Now);
            //Создание банковского счета с определенным балансом из входных данных.
            var AccountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Current, clock);
            //Выполнение операций с картой.
            AccountBank.Put(new Money(amountMoney));
            AccountBank.Withdraw(new Money(amountMoney));

            //Проверка правильности выполнения операций.
            //Проверка баланса.
            Assert.Equal(new Money(accountBalance), AccountBank.Balance);
            //Проверка количества прошедших транзакций.
            var countTransactionOperationFirstAccount = 2;
            Assert.Equal(countTransactionOperationFirstAccount, AccountBank.Transaction.Count);
            //Проверка прошедших транзакций для банковского счета.
            Assert.Equal(firstTransactionBankAcount, NextTransaction(AccountBank));
            Assert.Equal(secondTransactionBankAcount, NextTransaction(AccountBank));
        }

        [Theory]
        [InlineData(1000, 200, 800, 1200)]
        [InlineData(1000, 1000, 0, 2000)]
        public void Make_transfer_money_from_bank_account_on_bank_account(int balance, ushort withdrawAmounMoney, int firstAccountBalance, int secondAccountBalance)
        {
            var clock = new TestClock();
            var balanceAccount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var oneTransactionFirstAcount = new PaymentWithdrawBankTransaction(new Money(withdrawAmounMoney), 10000000, clock.Now, 10000001);
            var oneTransactionSecondAcount = new PaymentToPutBankTransaction(new Money(withdrawAmounMoney), 10000001, clock.Now);
            //Создание банковских счетов с определенным балансом из входных данных.
            var firstAccountBank = new BankAccount(10000000, balanceAccount, BankAccountType.Current, clock);
            var secondAccountBank = new BankAccount(10000001, balanceAccount, BankAccountType.Current, clock);
            //Выполнение перевода денег с счета на счет.
            firstAccountBank.TransferTo(secondAccountBank, new Money(withdrawAmounMoney));

            //Проверка правильности выполнения операций
            //Проверка баланса
            Assert.Equal(new Money(firstAccountBalance), firstAccountBank.Balance);
            Assert.Equal(new Money(secondAccountBalance), secondAccountBank.Balance);
            //Проверка прохождения транзакции
            Assert.Single(firstAccountBank.Transaction);
            Assert.Single(secondAccountBank.Transaction);
            //Проверка прошедших транзакций для первого счета
            Assert.Equal(oneTransactionFirstAcount, NextTransaction(firstAccountBank));
            //Проверка прошедших транзакций для второго счета
            Assert.Equal(oneTransactionSecondAcount, NextTransaction(secondAccountBank));
        }

        private BankTransaction NextTransaction(BankAccount transactions)
        {
            return transactions.Transaction.Dequeue();
        }
    }
}
