﻿using FourthLabWorkInSeventhChapters.Transaction;

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
        private const int MinNumberBankAccount = 10000000;
        private const int MaxNumberBankAccount = 99999999;

        private static int _number = 10000000;
        private readonly BankAccountType _type;
        private Queue<BankTransaction> _transaction;
        private ISystemClock _systemClock;

        private string TypeBankAccountUserFriendlyName => _type == BankAccountType.Saving ? "Сберегательный" : "Накопительный";

        public Queue<BankTransaction> Transaction => _transaction;

        public int NumberAccount { get; }

        public Money Money { get; private set; }

        public BankAccount(int balanceAcount) : this(balanceAcount, BankAccountType.Saving)
        { }

        public BankAccount(BankAccountType type) : this(0, type)
        { }

        public BankAccount(int balanceAcount, BankAccountType type) : this(GenerateNumberAccount(), balanceAcount, type)
        {
        }

        public BankAccount(int numberAccount, int balanceAcount, BankAccountType type) : this(numberAccount, balanceAcount, type, new SystemClock())
        {
        }

        public BankAccount(int numberAccount, int balanceAcount, BankAccountType type, ISystemClock clock)
        {
            if (numberAccount > MaxNumberBankAccount || numberAccount < MinNumberBankAccount)
                throw new Exception("Номер счета содержит 8 цифр!");
            if (balanceAcount < 0)
                throw new Exception("Баланс на счету должен быть отличным от нуля!");
            NumberAccount = numberAccount;
            Balance = balanceAcount;
            _type = type;
            _transaction = new Queue<BankTransaction>();
            _systemClock = clock;
            Money = new Money(balanceAcount);
        }

        public bool WithdrawMoney(ushort amount)
        {
            var amountMoney = new Money(amount);
            if (Money.Compare(Money, amountMoney) < 0)
                return false;
            Money.Withdraw(amountMoney);
            _transaction.Enqueue(new WithdrawalsFromAccountTransaction(amountMoney, NumberAccount, _systemClock.Now));
            return true;
        }

        public void PutMoney(ushort amount)
        {
            var amountMoney = new Money(amount);
            Money.Put(amountMoney);
            _transaction.Enqueue(new PutInAccountTransaction(amountMoney, NumberAccount, _systemClock.Now));
        }


        public bool TransferOfMoney(BankAccount account, ushort amount)
        {
            var amountMoney = new Money(amount);
            if (Money.Compare(Money, amountMoney) < 0)
                return false;
            WithdrawMoneyOfTransfer(amountMoney, account.NumberAccount);
            account.ToPutMoneyOfTransfer(amountMoney, account.NumberAccount);
            return true;
        }

        private static int GenerateNumberAccount()
        {
            if (_number + 1 <= MaxNumberBankAccount)
                return _number++;
            else
                throw new Exception("Номера банковских счетов закончились!");
        }

        private void WithdrawMoneyOfTransfer(Money amountMoney, int numberAccount)
        {
            Money.Withdraw(amountMoney);
            _transaction.Enqueue(new PaymentWithdrawBankTransaction(amountMoney, NumberAccount, _systemClock.Now, numberAccount));
        }

        private void ToPutMoneyOfTransfer(Money amountMoney, int numberAccount)
        {
            Money.Put(amountMoney);
            _transaction.Enqueue(new PaymentToPutBankTransaction(amountMoney, numberAccount, _systemClock.Now));
        }


        public override string ToString()
        {
            return string.Format("Номер счета:{0}. Баланс банковского счета {1} руб. Тип банковского счета - {2}", NumberAccount, Money, TypeBankAccountUserFriendlyName);
        }
    }
}
