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
*/

    public class BankAccount
    {
        private static int _number = 10000000;
        private readonly int _numberAccount;
        private int _balance;
        private readonly BankAccountType _type;

        private int GenerateNumberAccount => _number + 1 <= 99999999 ? _number++ : throw new Exception("Номера банковских счетов закончились!");

        private string TypeBankAccountUserFriendlyName => _type == BankAccountType.Saving ? "Сберегательный" : "Накопительный";

        public BankAccount(int numberAccount, int balanceAcount, BankAccountType type)
        {

            if (numberAccount >= 99999999 && numberAccount <= 10000000)
                throw new Exception("Номер счета содержит 8 цифр!");
            if (balanceAcount < 0)
                throw new Exception("Баланс на счету должен быть отличным от нуля!");
            _numberAccount = numberAccount;
            _balance = balanceAcount;
            _type = type;
        }

        public BankAccount(int balanceAcount, BankAccountType type)
        {
            if (balanceAcount < 0)
                throw new Exception("Баланс на счету должен быть отличным от нуля!");
            _numberAccount = GenerateNumberAccount;
            _balance = balanceAcount;
            _type = type;
        }

        public void WithdrawMoney(uint amountOfMony)
        {
            if (_balance >= amountOfMony)
                _balance -= (int)amountOfMony;
            else
                Console.WriteLine("{0} рублей снять не удалось с :", amountOfMony);
        }

        public void ToPutMoney(uint amountOfMony)
        {
            _balance += (int)amountOfMony;
        }

        public override string ToString()
        {
            return string.Format("Номер счета:{0}. Баланс банковского счета {1} руб. Тип банковского счета - {2}", _numberAccount, _balance, TypeBankAccountUserFriendlyName);
        }
    }
}
