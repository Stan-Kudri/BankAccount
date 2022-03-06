/*
Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер 
счета, баланс, тип банковского счета (использовать перечислимый тип из упр. 
3.1). Предусмотреть методы для доступа к данным – заполнения и чтения. 
Создать объект класса, заполнить его поля и вывести информацию об объекте 
класса на печать.

Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 таким 
образом, чтобы номер счета генерировался сам и был уникальным. Для этого 
надо создать в классе статическую переменную и метод, который увеличивает 
значение этого переменной.

Упражнение 7.3 Добавить в класс счет в банке два метода: снять со счета 
и положить на счет. Метод снять со счета проверяет, возможно ли снять 
запрашиваемую сумму, и в случае положительного результата изменяет баланс. 
*/

using FourthLabWorkInSeventhChapters;

RunNumberAccount();
Run();


void Run()
{
    ushort amountOfMoney = 0;
    var person1 = new BankAccount(new Money(5000), BankAccountType.Saving);
    person1.Withdraw(new Money(4900));
    Console.WriteLine(person1);
    amountOfMoney = 235;
    person1.Put(new Money(amountOfMoney));
    Console.WriteLine(person1);
    amountOfMoney = 456;
    person1.Put(new Money(amountOfMoney));
    amountOfMoney = 44424;
    person1.Put(new Money(amountOfMoney));
    amountOfMoney = 23242;
    if (person1.Withdraw(new Money(amountOfMoney)) == false)
        Console.WriteLine("{0} рублей снять не удалось :", amountOfMoney);


    var person2 = new BankAccount(new Money(10000), BankAccountType.Current);
    amountOfMoney = 1000;
    if (person2.TransferTo(person1, new Money(amountOfMoney)) == false)
        Console.WriteLine("{0} рублей для перевода с счета {1} нет", amountOfMoney, person2.NumberAccount);
    Console.WriteLine(person2);
    amountOfMoney = 55555;
    person2.Put(new Money(amountOfMoney));
    amountOfMoney = 32000;
    if (person1.TransferTo(person2, new Money(amountOfMoney)) == false)
        Console.WriteLine("{0} рублей для перевода с счета {1} нет", amountOfMoney, person2.NumberAccount);
    PrintOperation(person1.NumberAccount, person1.Transaction);
    PrintOperation(person2.NumberAccount, person2.Transaction);

    Console.WriteLine(person1);
    Console.WriteLine(person2);
    Console.WriteLine();
}

void RunNumberAccount()
{
    /*var line = "jjj";
    Console.WriteLine($"Строка :{line}");
    var account1 = new NumberBankAccount(line);
    PrintAccountNumber(account1.NumberAccount);
    line = "23334422";
    Console.WriteLine($"Строка :{line}");
    var account2 = new NumberBankAccount(line);
    PrintAccountNumber(account2.NumberAccount);*/
    var line = "233344222333 4422";
    Console.WriteLine($"Строка :{line}");
    var account3 = new NumberBankAccount(line);
    PrintAccountNumber(account3.NumberAccount);
    /*line = "0333 4422 2333 4422";
    Console.WriteLine($"Строка :{line}");
    var account4 = new NumberBankAccount(line);
    PrintAccountNumber(account4.NumberAccount);
    line = "233f 4422 2333 4422";
    Console.WriteLine($"Строка :{line}");
    var account5 = new NumberBankAccount(line);
    PrintAccountNumber(account5.NumberAccount);*/
}

void PrintOperation(int numberAccount, Queue<BankTransaction> _transaction)
{
    Console.WriteLine($"\nВыписка по счету {numberAccount}");
    foreach (var operation in _transaction)
    {
        Console.WriteLine(operation.ToString());

    }
}

void PrintAccountNumber(string? str)
{
    Console.WriteLine($"Правильный формат строки:{ str != null}");
    if (str != null)
    {
        Console.WriteLine(str);
    }
    Console.WriteLine();
}