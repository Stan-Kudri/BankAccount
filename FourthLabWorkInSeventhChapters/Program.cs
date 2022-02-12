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


var person1 = new BankAccount(5000, BankAccountType.Saving);
Console.WriteLine(person1);
person1.ToPutMoney(235);
Console.WriteLine(person1);
person1.ToPutMoney(456);
person1.ToPutMoney(44424);
person1.WithdrawMoney(23242);


var person2 = new BankAccount(10000, BankAccountType.Current);
person2.TransferOfMoney(person1, 1000);
Console.WriteLine(person2);
person2.ToPutMoney(55555);
person1.TransferOfMoney(person2, 32000);
person1.PrintOperation();
person2.PrintOperation();
