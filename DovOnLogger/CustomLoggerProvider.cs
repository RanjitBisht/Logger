using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DovOnLogger
{
    /// <summary>
    /// This is a custom logger provider which implements ILoggerProvider interface using namespace 'Microsoft.Extensions.Logging'
    /// This calss defines a set of methods of a logger provider must implement to instantiate a logger.
    /// </summary>
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers;

        public CustomLoggerProvider()
        {
            _loggers = new ConcurrentDictionary<string, CustomLogger>();
        }

        public ILogger CreateLogger(string strName)
        {
            var logger = _loggers.GetOrAdd(strName, new CustomLogger());

            return logger;
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
