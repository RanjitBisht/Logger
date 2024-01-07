using DovOnLogger.Entities;
using DovOnLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DovOnLogger
{
    public class FileLogger : ILoggerType
    {
        public void WriteMessage(LogData logData)
        {
            if ((logData != null) && (logData.Type.ToLower() == "file"))
            {
                // Code to write message on file
                string filePath = logData.Location.ToString() + logData.Name.ToString();

                File.WriteAllText(filePath, logData.Message);
            }
        }
    }
}
