namespace FourthLabWorkInSeventhChapters
{
    public class NumberBankAccount
    {
        const int stringSize = 19;
        public string? NumberAccount { get; }

        public NumberBankAccount(string line)
        {
            if (line == null)
                throw new Exception("Строка нулевая");
            if (!TryParseNumberAccount(line, out string? numberAccount))
                throw new Exception("Строка не правильного формата");
            NumberAccount = numberAccount;
        }

        private static bool TryParseNumberAccount(string line, out string? numberAccount)
        {
            var numberDigitBeforeSpace = 0;
            var number = stringSize;
            var charArray = new char[stringSize];
            numberAccount = null;
            foreach (var charElement in line.Where(x => x != ' '))
            {
                var IsFirstElementZero = number == stringSize && charElement == '0';
                if (!char.IsNumber(charElement) || IsFirstElementZero || number < 1)
                {
                    return false;
                }
                if (numberDigitBeforeSpace == 4)
                {
                    charArray[stringSize - number] = ' ';
                    number--;
                    numberDigitBeforeSpace = 0;
                }
                charArray[stringSize - number] = charElement;
                number--;
                numberDigitBeforeSpace++;
            }
            if (number != 0)
                return false;
            numberAccount = new string(charArray);
            return true;
        }
    }
}
