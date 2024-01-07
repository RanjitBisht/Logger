using DovOnLogger.Entities;
using DovOnLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovOnLogger
{
    public class ExceptionLogger : ILoggerType
    {
        private ILoggerType _loggerType;

        public ExceptionLogger(ILoggerType loggerType) 
        { 
            _loggerType = loggerType;
        }

        public void WriteMessage(LogData logData)
        {
            this._loggerType.WriteMessage(logData);
        }
    }
}
