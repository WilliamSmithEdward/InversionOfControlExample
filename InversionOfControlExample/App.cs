namespace InversionOfControlExample
{
    internal class App
    {
        private readonly ILogger _logger;

        public App(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Application is running.");
        }
    }
}
