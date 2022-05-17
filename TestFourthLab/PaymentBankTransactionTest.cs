using FourthLabWorkInSeventhChapters;
using FourthLabWorkInSeventhChapters.Transaction;
using Xunit;

namespace TestFourthLab
{
    public class PaymentBankTransactionTest
    {
        [Theory]
        [InlineData(1000, 200)]
        [InlineData(1000, 300)]
        public void Make_multiple_transactions(int balance, ushort amountMoney)
        {
            var clock = new TestClock();
            var balanceAccount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var firstTransactionBankAcount = new WithdrawalsFromAccountTransaction(new Money(amountMoney), new NumberBankAccount("1000 0000 0000 0000"), clock.Now);
            var secondTransactionBankAcount = new PutInAccountTransaction(new Money(amountMoney), new NumberBankAccount("1000 0000 0000 0000"), clock.Now);
            //Создание банковского счета с определенным балансом из входных данных.
            var AccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0000"), balanceAccount, BankAccountType.Current, clock);
            //Выполнение операций с картой.
            AccountBank.Withdraw(new Money(amountMoney));
            AccountBank.Put(new Money(amountMoney));

            //Проверка баланса.
            Assert.Equal(new Money(balance), AccountBank.Balance);
            //Проверка количества прошедших транзакций (2 транзакции = снятие денег со счета + пополнение счета деньгами).
            var countTransactionOperationFirstAccount = 2;
            Assert.Equal(countTransactionOperationFirstAccount, AccountBank.Transaction.Count);
            //Проверка прошедших транзакций для банковского счета.
            Assert.Equal(firstTransactionBankAcount, AccountBank.PopLastTransaction());
            Assert.Equal(secondTransactionBankAcount, AccountBank.PopLastTransaction());
        }

        [Theory]
        [InlineData(1000, 200, 800, 1200)]
        [InlineData(1000, 1000, 0, 2000)]
        public void Make_transfer_money_from_bank_account_on_bank_account(int balance, ushort transferAmounMoney, int firstAccountBalance, int secondAccountBalance)
        {
            var clock = new TestClock();
            var balanceAccount = new Money(balance);
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            var transactionFirstAcount = new PaymentWithdrawBankTransaction(new Money(transferAmounMoney), new NumberBankAccount("1000 0000 0000 0000"), clock.Now, new NumberBankAccount("1000 0000 0000 0001"));
            var transactionSecondAcount = new PaymentToPutBankTransaction(new Money(transferAmounMoney), new NumberBankAccount("1000 0000 0000 0001"), clock.Now);
            //Создание банковских счетов с определенным балансом из входных данных.
            var firstAccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0000"), balanceAccount, BankAccountType.Current, clock);
            var secondAccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0001"), balanceAccount, BankAccountType.Current, clock);
            //Выполнение перевода денег с счета на счет.
            firstAccountBank.TransferTo(secondAccountBank, new Money(transferAmounMoney));

            //Проверка баланса
            Assert.Equal(new Money(firstAccountBalance), firstAccountBank.Balance);
            Assert.Equal(new Money(secondAccountBalance), secondAccountBank.Balance);
            //Проверка прохождения транзакции.
            Assert.Single(firstAccountBank.Transaction);
            Assert.Single(secondAccountBank.Transaction);
            //Проверка прошедшей транзакции для счетов.
            Assert.Equal(transactionFirstAcount, firstAccountBank.PopLastTransaction());
            Assert.Equal(transactionSecondAcount, secondAccountBank.PopLastTransaction());
        }
    }
}
