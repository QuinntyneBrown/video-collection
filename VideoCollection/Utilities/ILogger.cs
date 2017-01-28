namespace VideoCollection.Utilities
{
    public interface ILogger
    {
        void AddProvider(ILoggerProvider provider);
    }
}
