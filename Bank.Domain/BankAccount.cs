using Bank.Domain.Transaction;
using System.Text;

namespace Bank.Domain
{
    /*
Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер 
счета, баланс, тип банковского счета (использовать перечислимый тип из упр. 
3.1). Предусмотреть методы для доступа к данным – заполнения и чтения. 
Создать объект класса, заполнить его поля и вывести информацию об объекте 
класса на печать.

Упражнение 3.1 Создать перечислимый тип данных отображающий 
виды банковского счета (текущий и сберегательный). Создать переменную типа 
перечисления, присвоить ей значение и вывести это значение на печать.

Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 таким 
образом, чтобы номер счета генерировался сам и был уникальным. Для этого 
надо создать в классе статическую переменную и метод, который увеличивает 
значение этого переменной.

Упражнение 7.3 Добавить в класс счет в банке два метода: снять со счета 
и положить на счет. Метод снять со счета проверяет, возможно ли снять 
запрашиваемую сумму, и в случае положительного результата изменяет баланс. 

Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1-
7.3 добавить метод, который переводит деньги с одного счета на другой. У 
метода два параметра: ссылка на объект класса банковский счет откуда 
снимаются деньги, второй параметр – сумма

Упражнение 9.1 В классе банковский счет, созданном в предыдущих 
упражнениях, удалить методы заполнения полей. Вместо этих методов создать 
конструкторы. Переопределить конструктор по умолчанию, создать 
конструктор для заполнения поля баланс, конструктор для заполнения поля тип 
банковского счета, конструктор для заполнения баланса и типа банковского 
счета. Каждый конструктор должен вызывать метод, генерирующий номер 
счета.

Упражнение 9.2 Создать новый класс BankTransaction, который будет 
хранить информацию о всех банковских операциях. При изменении баланса 
счета создается новый объект класса BankTransaction, который содержит 
текущую дату и время, добавленную или снятую со счета сумму. Поля класса 
должны быть только для чтения (readonly). Конструктору класса передается 
один параметр – сумма. 
В классе банковский счет добавить закрытое поле типа 
System.Collections.Queue, которое будет хранить объекты класса 
BankTransaction для данного банковского счета; изменить методы снятия со 
счета и добавления на счет так, чтобы в них создавался объект класса 
BankTransaction и каждый объект добавлялся в переменную типа 
System.Collections.Queue.*/

    public class BankAccount
    {
        private readonly BankAccountType _type;
        private Queue<BankTransaction> _transaction;
        private ISystemClock _systemClock;
        private readonly NumberBankAccount _numberAccount;

        private string TypeBankAccountUserFriendlyName => _type == BankAccountType.Saving ? "Сберегательный" : "Накопительный";

        public Queue<BankTransaction> Transaction => _transaction;

        public NumberBankAccount NumberAccount
        {
            get => _numberAccount;
        }

        public Money Balance { get; private set; }

        internal BankAccount(Money initBalance) : this(initBalance, BankAccountType.Saving)
        { }

        internal BankAccount(BankAccountType type) : this(new Money(0), type)
        { }

        internal BankAccount(Money initBalance, BankAccountType type) : this(GenerateNumberAccount(), initBalance, type)
        {
        }

        internal BankAccount(string numberAccount, Money initBalance, BankAccountType type) : this(numberAccount, initBalance, type, new SystemClock())
        {
        }

        internal BankAccount(string numberAccount, Money initBalance, BankAccountType type, ISystemClock clock)
        {
            if (numberAccount == null)
                throw new ArgumentNullException("Номер счета = пустое начение");
            _numberAccount = new NumberBankAccount(numberAccount);
            _type = type;
            _transaction = new Queue<BankTransaction>();
            _systemClock = clock;
            Balance = initBalance;
        }

        public BankTransaction PopLastTransaction()
        {
            return _transaction.Dequeue();
        }

        public bool Withdraw(Money amount)
        {
            if (Balance < amount || IsZero(amount))
                return false;

            Balance -= amount;
            AddTransaction(new WithdrawalsFromAccountTransaction(amount, NumberAccount, _systemClock.Now));

            return true;
        }

        public bool Put(Money amount)
        {
            if (IsZero(amount))
                return false;

            Balance += amount;
            AddTransaction(new PutInAccountTransaction(amount, NumberAccount, _systemClock.Now));
            return true;
        }


        public bool TransferTo(BankAccount account, Money amount)
        {
            if (Balance < amount || IsZero(amount))
                return false;

            Balance -= amount;
            AddTransaction(new PaymentWithdrawBankTransaction(amount, NumberAccount, _systemClock.Now, account.NumberAccount));

            account.Balance += amount;
            account.AddTransaction(new PaymentToPutBankTransaction(amount, account.NumberAccount, _systemClock.Now));

            return true;
        }

        private void AddTransaction(BankTransaction transaction)
        {
            _transaction.Enqueue(transaction);
        }

        public override string ToString()
        {
            return string.Format("Номер счета:{0}. Баланс банковского счета {1} руб. Тип банковского счета - {2}", NumberAccount, Balance, TypeBankAccountUserFriendlyName);
        }

        private static bool IsZero(Money amount) => amount.Equals(new Money(0));

        public static string GenerateNumberAccount()
        {
            Random random = new Random();
            var numberBuilder = new StringBuilder();
            for (int i = 1; i <= 16; i++)
            {
                numberBuilder.Append(random.Next(0, 9));
                if (i == 4)
                    numberBuilder.Append(' ');
            }
            return numberBuilder.ToString();
        }
    }
}
