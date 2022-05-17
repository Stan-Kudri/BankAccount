namespace Bank.Domain
{
    public class FormatNumberAccountException : Exception
    {
        public FormatNumberAccountException(string message) : base(message) { }
    }
}
