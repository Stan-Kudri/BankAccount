namespace FourthLabWorkInSeventhChapters
{
    public class Clock : ISystemClock
    {
        public DateTime Not { get; set; } = DateTime.Now;
    }
}
