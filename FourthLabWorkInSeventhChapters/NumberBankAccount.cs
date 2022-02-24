namespace FourthLabWorkInSeventhChapters
{
    public class NumberBankAccount
    {
        public string? NumberAccount { get; set; }

        public NumberBankAccount(string line)
        {
            CheckNullString(line);
            TryParseNumberAccount(line, out string? numberAccount);
            NumberAccount = numberAccount;
            if (NumberAccount != null)
                NumberAccount = StringFormat(NumberAccount);
        }

        private static bool TryParseNumberAccount(string line, out string? numberAccount)
        {
            var number = 16;
            var charArray = new char[16];
            numberAccount = null;
            foreach (var charElement in line.Where(x => x != ' '))
            {
                var IsFirstElementZero = number == 16 && charElement == '0';
                if (!char.IsNumber(charElement) || IsFirstElementZero || number < 1)
                {
                    return false;
                }
                charArray[16 - number] = charElement;
                number--;
            }
            if (number != 0)
                return false;
            numberAccount = new string(charArray);
            return true;
        }

        private static string StringFormat(string numberAccount)
        {
            var number = 0;
            var numberDigitBeforeSpace = 0;
            var charArray = new char[19];
            foreach (var charElement in numberAccount)
            {
                if (numberDigitBeforeSpace == 4)
                {
                    charArray[number] = ' ';
                    number++;
                    numberDigitBeforeSpace = 0;
                }
                charArray[number] = charElement;
                number++;
                numberDigitBeforeSpace++;
            }
            return new string(charArray);
        }

        private bool CheckNullString(string line)
        {
            if (line == null)
                throw new Exception("Строка нулевая");
            return true;
        }

    }
}
