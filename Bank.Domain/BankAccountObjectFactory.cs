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
        private Dictionary<NumberBankAccount, BankAccount> hashtable = new Dictionary<NumberBankAccount, BankAccount>();

        public bool Active(NumberBankAccount bankAccountNumber) => hashtable.ContainsKey(bankAccountNumber);

        public BankAccount CreateAccount(BankAccountType type)
        {
            return CreateAccount(new Money(0), type);
        }

        public BankAccount CreateAccount(Money initBalance, BankAccountType type = BankAccountType.Saving)
        {
            var bankAccount = new BankAccount(initBalance, type);
            var numberBankAccount = bankAccount.NumberAccount;

            hashtable.Add(numberBankAccount, bankAccount);
            return bankAccount;
        }

        public BankAccount CreateAccount(string numberAccount, Money initBalance, BankAccountType type)
        {
            return CreateAccount(numberAccount, initBalance, type, new SystemClock());
        }

        public BankAccount CreateAccount(string numberAccount, Money initBalance, BankAccountType type, ISystemClock clock)
        {
            var bankAccount = new BankAccount(new NumberBankAccount(numberAccount), initBalance, type, clock);
            var numberBankAccount = bankAccount.NumberAccount;

            hashtable.Add(numberBankAccount, bankAccount);
            return bankAccount;
        }

        public void Close(NumberBankAccount numberAccount) => hashtable.Remove(numberAccount);

    }
}
