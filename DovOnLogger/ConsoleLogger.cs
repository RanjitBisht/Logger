using DovOnLogger.Entities;
using DovOnLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovOnLogger
{
    public class ConsoleLogger : ILoggerType
    {
        public void WriteMessage(LogData logData)
        {
            if((logData != null) && (logData.Type.ToLower() == "concole"))
            {
                // Code to write message on Console
                Console.WriteLine(logData.Message.ToString());
            }
        }
    }
}
