//William Smith
//2023-08-16
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InversionOfControlExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dependency Injection + IoC with ConsoleLogger class implementation
            var serviceProvider = new ServiceCollection()
                .AddTransient<ILogger, ConsoleLogger>()
                .AddTransient<App>()
                .BuildServiceProvider();

            var app = serviceProvider.GetService<App>();
            app.Run();

            //Dependency Injection + IoC with ConsoleLoggerNew class implementation
            var serviceProvider2 = new ServiceCollection()
                .AddTransient<ILogger, ConsoleLoggerNew>()
                .AddTransient<App>()
                .BuildServiceProvider();

            app = serviceProvider2.GetService<App>();
            app.Run();

            //Dependency Injection + IoC with dynamic class implementation based on a configuration in a JSON config file
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceProvider3 = new ServiceCollection()
                .Configure<LoggerSettings>(configuration.GetSection("LoggerSettings"))
                .AddTransient<ILogger>(provider =>
                {
                    var loggerSettings = provider.GetRequiredService<IOptions<LoggerSettings>>().Value;
                    if (loggerSettings.UseNewFileLogger)
                    {
                        return new ConsoleLoggerNew();
                    }
                    else
                    {
                        return new ConsoleLogger();
                    }
                })
                .AddTransient<App>()
                .BuildServiceProvider();

            app = serviceProvider3.GetService<App>();
            app.Run();
        }
    }
}