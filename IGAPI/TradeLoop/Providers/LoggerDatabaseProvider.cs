using Data.Dto;
using DataFactory.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TradeLoop.Providers;

public static class LoggerDatabaseProviderExtensions
{
    public static ILoggingBuilder AddDatabaseLogger(
        this ILoggingBuilder builder)
    {
        builder.AddProvider(new LoggerDatabaseProvider(builder.Services));
        return builder;
    }
}

public class LoggerDatabaseProvider : ILoggerProvider
{
    private readonly IServiceCollection _services;

    public LoggerDatabaseProvider(IServiceCollection services)
    {
        _services = services;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new Logger(categoryName, _services);
    }

    public void Dispose()
    {
    }

    public class Logger : ILogger
    {
        private readonly string _categoryName;
        private readonly IServiceCollection _services;

        private ILoggerDataService? _loggerDataService;

        public Logger(string categoryName, IServiceCollection service)
        {
            _categoryName = categoryName;
            _services = service;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _loggerDataService = GetService();

            if (logLevel is LogLevel.Critical or LogLevel.Error)
            {
                RecordMsg(logLevel, eventId, state, exception, formatter);
                return;
            }

            if (_categoryName is "Microsoft.EntityFrameworkCore.Database.Command"
                or "Microsoft.EntityFrameworkCore.Infrastructure" or "Microsoft.EntityFrameworkCore.Query")
                return;

            RecordMsg(logLevel, eventId, state, exception, formatter);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        private ILoggerDataService? GetService()
        {
            var loggerDataService =
                _loggerDataService ?? _services.BuildServiceProvider().GetService<ILoggerDataService>();
            return loggerDataService;
        }

        private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _loggerDataService = GetService();
            _loggerDataService?.Log(new LogDto
            {
                LogLevel = logLevel.ToString(),
                CategoryName = _categoryName,
                Msg = formatter(state, exception),
                User = "username",
                Timestamp = DateTime.Now
            });
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}