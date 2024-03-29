﻿namespace Bank.Domain
{
    public abstract class BankTransaction : IEquatable<BankTransaction>
    {
        protected readonly NumberBankAccount _numberAccount;
        protected readonly Money _money;

        protected readonly DateTime _dateTime;

        public BankTransaction(Money amount, NumberBankAccount numberAccount, DateTime dateTime)
        {
            _money = amount;
            _dateTime = dateTime;
            _numberAccount = numberAccount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is BankTransaction transaction)
                return Equals(transaction);
            return false;
        }

        public bool Equals(BankTransaction? other)
        {
            if (other == null)
                return false;
            return other._dateTime == _dateTime && _numberAccount.Equals(other._numberAccount) && other._money == _money && other.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_money, _dateTime, _numberAccount, GetType());
        }
    }
}
