namespace Bank.Domain
{
    public interface ISystemClock
    {
        DateTime Now { get; }
    }
}