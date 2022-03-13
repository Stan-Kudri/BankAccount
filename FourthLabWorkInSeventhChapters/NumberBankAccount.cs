using System.Text;

namespace FourthLabWorkInSeventhChapters
{
    public class NumberBankAccount
    {
        const int SizeOfNumberAccount = 19;

        private static readonly Random random = new();

        private readonly string _numberAccount;

        public string NumberAccount => _numberAccount;

        public NumberBankAccount() : this(GenerateNumberAccount())
        {

        }

        public NumberBankAccount(string line)
        {
            _numberAccount = ParseNumberAccount(line);
        }

        private static string GenerateNumberAccount()
        {
            var strBuilder = new StringBuilder();
            for (var i = 0; i <= 3; i++)
            {
                if (i != 0)
                    strBuilder.Append(' ');
                strBuilder.Append(random.Next(1000, 9999));
            }
            return strBuilder.ToString();
        }

        private static string ParseNumberAccount(string line)
        {
            if (line == null)
                throw new ArgumentNullException("Строка нулевая");

            var numberDigitBeforeSpace = 0;
            var number = SizeOfNumberAccount;
            var charArray = new char[SizeOfNumberAccount];
            foreach (var charElement in line.Where(x => x != ' '))
            {
                var IsFirstElementZero = number == SizeOfNumberAccount && charElement == '0';
                if (!char.IsNumber(charElement) || IsFirstElementZero || number < 1)
                {
                    throw new FormatNumberAccountException("Строка не правильного формата");
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
                throw new FormatNumberAccountException("Строка не правильного формата");
            }
            return new string(charArray);
        }

        public static bool operator ==(NumberBankAccount left, NumberBankAccount right)
        {
            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        public static bool operator !=(NumberBankAccount left, NumberBankAccount right)
        {
            return left != right;
        }

        public bool Equals(NumberBankAccount? numberBankAccount)
        {
            if (ReferenceEquals(numberBankAccount, null))
                return false;
            return numberBankAccount._numberAccount == _numberAccount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is NumberBankAccount numberBankAccount)
                return Equals(numberBankAccount);
            return false;
        }

        public override string ToString()
        {
            return _numberAccount;
        }


        public override int GetHashCode()
        {
            return _numberAccount.GetHashCode();
        }
    }
}
