namespace InversionOfControlExample
{
    internal class ConsoleLoggerNew : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Using the implementation of Log(string message) in the ConsoleLoggerNew class: " + message);
        }
    }
}
