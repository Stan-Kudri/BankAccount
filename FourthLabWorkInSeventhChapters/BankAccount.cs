using FourthLabWorkInSeventhChapters.Transaction;

namespace FourthLabWorkInSeventhChapters
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
        private static int _number = 10000000;
        private readonly int _numberAccount;
        private int _balance;
        private readonly BankAccountType _type;
        private Queue<BankTransaction> _transaction;

        private string TypeBankAccountUserFriendlyName => _type == BankAccountType.Saving ? "Сберегательный" : "Накопительный";

        public Queue<BankTransaction> Transaction => _transaction;

        public int NumberAccount { get => _numberAccount; }

        public int Balance { get => _balance; }

        public BankAccount(int balanceAcount) : this(balanceAcount, BankAccountType.Saving)
        { }

        public BankAccount(BankAccountType type) : this(0, type)
        { }

        public BankAccount(int balanceAcount, BankAccountType type) : this(GenerateNumberAccount(), balanceAcount, type)
        {
        }

        public BankAccount(int numberAccount, int balanceAcount, BankAccountType type)
        {

            if (numberAccount > 99999999 || numberAccount < 10000000)
                throw new Exception("Номер счета содержит 8 цифр!");
            if (balanceAcount < 0)
                throw new Exception("Баланс на счету должен быть отличным от нуля!");
            _numberAccount = numberAccount;
            _balance = balanceAcount;
            _type = type;
            _transaction = new Queue<BankTransaction>();
        }

        public bool WithdrawMoney(ushort amountOfMony)
        {
            if (_balance < amountOfMony)
                return false;
            _balance -= (int)amountOfMony;
            _transaction.Enqueue(new WithdrawalsFromAccountTransaction(amountOfMony, _numberAccount));
            return true;
        }

        public void PutMoney(ushort amountOfMony)
        {
            _balance += (int)amountOfMony;
            _transaction.Enqueue(new PutInAccountTransaction(amountOfMony, _numberAccount));
        }

        public bool TransferOfMoney(BankAccount account, ushort amountOfMony)
        {
            if (_balance < amountOfMony)
                return false;
            WithdrawMonyOfTransfer(amountOfMony, account._numberAccount);
            account.ToPutMonyOfTransfer(amountOfMony, account._numberAccount);
            return true;

        }

        private static int GenerateNumberAccount()
        {
            if (_number + 1 <= 99999999)
                return _number++;
            else
                throw new Exception("Номера банковских счетов закончились!");
        }

        private void WithdrawMonyOfTransfer(ushort amountOfMony, int numberAccount)
        {
            _balance -= (int)amountOfMony;
            _transaction.Enqueue(new PaymentWithdrawBankTransaction(amountOfMony, _numberAccount, numberAccount));
        }

        private void ToPutMonyOfTransfer(ushort amountOfMony, int numberAccount)
        {
            _balance += (int)amountOfMony;
            _transaction.Enqueue(new PaymentToPutBankTransaction(amountOfMony, numberAccount));
        }


        public override string ToString()
        {
            return string.Format("Номер счета:{0}. Баланс банковского счета {1} руб. Тип банковского счета - {2}", _numberAccount, _balance, TypeBankAccountUserFriendlyName);
        }
    }
}
