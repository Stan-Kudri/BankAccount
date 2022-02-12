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
        private static int _numberRandom = new Random().Next(10000000, 99999999);
        private readonly int _numberAccount;
        private int _balance;
        private readonly BankAccountType _type;

        public BankAccount()
        {
            _numberAccount = GenerateNumberAccount;
            _balance = 5000000;
            _type = BankAccountType.Saving;
        }

        public BankAccount(int numberAccount, int balanceAcount, BankAccountType type)
        {
            ValidateAcountBalance(numberAccount, balanceAcount);
            _numberAccount = numberAccount;
            _balance = balanceAcount;
            _type = type;
        }

        public void WithdrawMoney(int amountOfMony)
        {
            ValidateOperationOfAmountValue(amountOfMony);
            if (_balance >= amountOfMony)
                _balance -= amountOfMony;
        }

        public void ToPutMoney(int amountOfMony)
        {
            ValidateOperationOfAmountValue(amountOfMony);
            _balance += amountOfMony;
        }

        public override string ToString()
        {
            return string.Format("Номер счета:{0}. Баланс банковского счета {1} руб. Тип банковского счета - {2}", _numberAccount, _balance, TypeBankAccount());
        }

        public static void Run()
        {
            var person = new BankAccount();
            Console.WriteLine(person);
            person.ToPutMoney(235);
            Console.WriteLine(person);
            person.WithdrawMoney(500000);
            Console.WriteLine(person);
            var parson1 = new BankAccount(12345678, 500, BankAccountType.Saving);
            Console.WriteLine(parson1);
        }

        private static int GenerateNumberAccount
        {
            get
            {
                var value = 15;
                return _numberRandom + value <= 99999999 ? _numberRandom + value : _numberRandom - 555;
            }
        }

        private string TypeBankAccount() => _type == BankAccountType.Saving ? "Сберегательный" : "Накопительный";

        private static void ValidateAcountBalance(int numberAccount, int balanceAcount)
        {
            if (numberAccount >= 99999999 && numberAccount <= 10000000)
                throw new Exception("Номер счета содержит 8 цифр!");
            if (balanceAcount < 0)
                throw new Exception("Баланс на счету должен быть отличным от нуля!");
        }

        private void ValidateOperationOfAmountValue(int amountValue)
        {
            if (amountValue < 0)
                throw new Exception("Деньги при проведении операции должны быть с положительным значением!");
        }
    }
}
