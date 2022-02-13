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


Run();


void Run()
{
    ushort amountOfMony = 0;
    var person1 = new BankAccount(5000, BankAccountType.Saving);
    Console.WriteLine(person1);
    amountOfMony = 235;
    person1.ToPutMoney(amountOfMony);
    Console.WriteLine(person1);
    amountOfMony = 456;
    person1.ToPutMoney(amountOfMony);
    amountOfMony = 44424;
    person1.ToPutMoney(amountOfMony);
    amountOfMony = 23242;
    if (person1.WithdrawMoney(amountOfMony) == false)
        Console.WriteLine("{0} рублей снять/перевести не удалось :", amountOfMony);


    var person2 = new BankAccount(10000, BankAccountType.Current);
    amountOfMony = 1000;
    if (person2.TransferOfMoney(person1, amountOfMony) == false)
        Console.WriteLine("{0} рублей для перевода с счета {1} нет", amountOfMony, person2.NumberAccount);
    Console.WriteLine(person2);
    amountOfMony = 55555;
    person2.ToPutMoney(amountOfMony);
    amountOfMony = 32000;
    if (person1.TransferOfMoney(person2, amountOfMony) == false)
        Console.WriteLine("{0} рублей для перевода с счета {1} нет", amountOfMony, person2.NumberAccount);
    PrintOperation(person1.NumberAccount, person1.Transaction);
    PrintOperation(person2.NumberAccount, person2.Transaction);
}

void PrintOperation(int numberAccount, Queue<BankTransaction> _transaction)
{
    Console.WriteLine($"\nВыписка по счету {numberAccount}");
    foreach (var operation in _transaction)
    {
        Console.WriteLine(operation);
    }
}