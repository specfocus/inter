namespace XState.State
{
    public interface ISchedulerOptions
    {
        bool DeferEvents { get; }
    }

    public class SchedulerOptions : ISchedulerOptions
    {
        public bool DeferEvents { get; set; } = false;
    }
}
