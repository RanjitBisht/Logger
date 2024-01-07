using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DovOnLogger
{
    /// <summary>
    /// This is a custom logger class which implements ILoger interface using namespace 'Microsoft.Extensions.Logging'
    /// This ILoger interface provides to write log messages which can route to different providers like console, file, or any third-party logging service
    /// </summary>
    public class CustomLogger : ILogger
    {
        public CustomLogger() { }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;


        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
        }
    }
}
