﻿namespace Bank.Domain.Transaction
{
    public class PutInAccountTransaction : BankTransaction
    {
        public PutInAccountTransaction(Money amount, NumberBankAccount numberAccount, DateTime dateTime) : base(amount, numberAccount, dateTime)
        {
        }

        public override string ToString()
        {
            return string.Format($"Пополнение {_numberAccount} счета на сумму {_money}: {_dateTime}");
        }
    }
}
