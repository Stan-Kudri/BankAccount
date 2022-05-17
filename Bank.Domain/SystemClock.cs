namespace Bank.Domain
{
    public class SystemClock : ISystemClock
    {
        public DateTime Now => DateTime.Now;
    }
}
