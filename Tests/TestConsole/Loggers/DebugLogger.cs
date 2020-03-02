namespace TestConsole
{
    public abstract class DebugLogger : Logger
    {
        public abstract void Log(string Message, string Category);
    }
}
