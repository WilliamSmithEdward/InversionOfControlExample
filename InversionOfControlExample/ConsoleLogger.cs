namespace InversionOfControlExample
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Using the implementation of Log(string message) in the ConsoleLogger class: " + message);
        }
    }
}
