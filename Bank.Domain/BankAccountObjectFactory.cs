using System.Collections;

/*Упражнение 11.1 Создать новый класс, который будет являться 
фабрикой объектов класса банковский счет. Изменить модификатор доступа у 
конструкторов класса банковский счет на internal. Добавить в фабричный класс 
перегруженные методы создания счета CreateAccount, которые бы вызывали 
конструктор класса банковский счет и возвращали номер созданного счета. 
Использовать хеш-таблицу для хранения всех объектов банковских счетов в 
фабричном классе. В фабричном классе предусмотреть метод закрытия счета,
который удаляет счет из хеш-таблицы (методу в качестве параметра передается 
номер банковского счета).*/

namespace Bank.Domain
{
    public class BankAccountObjectFactory
    {
        private static Hashtable hashtable = new Hashtable(new Dictionary<int, BankAccount>());

        public BankAccount Hashtable(int bankAccountID)
        {
            if (!hashtable.ContainsValue(bankAccountID))
                throw new ArgumentException("Не существует такого счета");
            return (BankAccount)hashtable[bankAccountID];
        }

        public BankAccount CreateAccount(Money initBalance)
        {
            return CreateAccount(initBalance, BankAccountType.Saving);
        }

        public BankAccount CreateAccount(BankAccountType type)
        {
            return CreateAccount(new Money(0), type);
        }

        public BankAccount CreateAccount(Money initBalance, BankAccountType type)
        {
            var bankAccount = new BankAccount(initBalance, type);
            var numberBankAccount = bankAccount.NumberAccount;

            hashtable.Add(numberBankAccount, bankAccount);
            return bankAccount;
        }

        public BankAccount CreateAccount(int numberAccount, Money initBalance, BankAccountType type)
        {
            return CreateAccount(numberAccount, initBalance, type, new SystemClock());
        }

        public BankAccount CreateAccount(int numberAccount, Money initBalance, BankAccountType type, ISystemClock clock)
        {
            var bankAccount = new BankAccount(numberAccount, initBalance, type, clock);
            var numberBankAccount = bankAccount.NumberAccount;

            hashtable.Add(numberBankAccount, bankAccount);
            return bankAccount;
        }

        public void Remove(int numberAccount) => hashtable.Remove(numberAccount);

    }
}
