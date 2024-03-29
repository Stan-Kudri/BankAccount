﻿namespace Bank.Domain
{
    public class NumberBankAccount
    {
        const int SizeOfNumberAccount = 19;

        private string _numberAccount;

        public string NumberAccount => _numberAccount;

        public NumberBankAccount(string line)
        {
            if (line == null)
                throw new ArgumentNullException("Строка нулевая");
            if (!TryParseNumberAccount(line, out string numberAccount))
                throw new FormatNumberAccountException("Строка не правильного формата");
            _numberAccount = numberAccount;
        }

        private static bool TryParseNumberAccount(string line, out string numberAccount)
        {
            var numberDigitBeforeSpace = 0;
            var number = SizeOfNumberAccount;
            var charArray = new char[SizeOfNumberAccount];
            foreach (var charElement in line.Where(x => x != ' '))
            {
                var IsFirstElementZero = number == SizeOfNumberAccount && charElement == '0';
                if (!char.IsNumber(charElement) || IsFirstElementZero || number < 1)
                {
                    numberAccount = string.Empty;
                    return false;
                }
                if (numberDigitBeforeSpace == 4)
                {
                    charArray[SizeOfNumberAccount - number] = ' ';
                    number--;
                    numberDigitBeforeSpace = 0;
                }
                charArray[SizeOfNumberAccount - number] = charElement;
                number--;
                numberDigitBeforeSpace++;
            }
            if (number != 0)
            {
                numberAccount = string.Empty;
                return false;
            }
            numberAccount = new string(charArray);
            return true;
        }

        public override string ToString() => _numberAccount;

        public bool Equals(NumberBankAccount? number)
        {
            if (number == null)
                return false;
            return _numberAccount == number._numberAccount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is NumberBankAccount number)
                return Equals(number);
            return false;
        }

        public override int GetHashCode()
        {
            return _numberAccount.GetHashCode();
        }
    }
}
