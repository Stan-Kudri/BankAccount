namespace FourthLabWorkInSeventhChapters
{
    public class BankTransaction
    {
        private readonly DateTime _dateTime;
        private readonly int _amountOfMony;
        private readonly int _numberAccountOfTransfer;
        private readonly Operation _operation;

        public BankTransaction(int amountOfMony, Operation operation)
        {
            _amountOfMony = amountOfMony;
            _dateTime = DateTime.Now;
            _operation = operation;
        }

        public BankTransaction(int amountOfMony, int numberAccount, Operation operation)
        {
            _amountOfMony = amountOfMony;
            _dateTime = DateTime.Now;
            _numberAccountOfTransfer = numberAccount;
            _operation = operation;
        }

        public override string ToString()
        {
            if (_operation == Operation.PaymentToPut)
            {
                return string.Format($"Пополнение счета на сумму {_amountOfMony}: {_dateTime}");
            }
            else if (_operation == Operation.PaymentWithdraw)
            {
                return string.Format($"Списание со счета суммы {_amountOfMony}: {_dateTime}");
            }
            else if (_operation == Operation.TransferWithdraw)
            {
                return string.Format($"Перевод с карты на счет {_numberAccountOfTransfer} {_amountOfMony} рублей : {_dateTime}");
            }
            else if (_operation == Operation.TransferToPut)
            {
                return string.Format($"Получение {_amountOfMony} рублей с карты {_numberAccountOfTransfer}: {_dateTime}");
            }
            return string.Empty;
        }
    }
}
