using DovOnLogger;
using DovOnLogger.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinkApp.Model;
using System.Net;

namespace SinkApp.Controllers
{
    public class FileController : BaseController
    {
        private ILogger _logger;

        public FileController(ILoggerProvider loggerProvider)
        {
            _logger = loggerProvider.CreateLogger(nameof(FileController));
        }
        public IActionResult Index()
        {
            return null;
        }

        [HttpGet]
        // GET: FileController/Details
        public DisplayMessage Details()
        {
            ExceptionLogger exceptionLogger = null;
            LogData logData = new LogData();
            DisplayMessage displayMessage = new DisplayMessage();

            try
            {
                logData.Id = 2;
                logData.Type = "File";
                logData.LogLevel = "Warning";
                logData.Name = "ErrorFile_1.txt";
                logData.Location = @"D:/";
                logData.Message = "This is a warning message!";

                exceptionLogger = new ExceptionLogger(new FileLogger());

                _logger.LogWarning(logData.Message.ToString());
                exceptionLogger.WriteMessage(logData);

                // Raise faile exception
                RaiseException();
            }
            catch (Exception ex)
            {
                logData.LogLevel = "Error";
                logData.Message = ex.Message.ToString();

                _logger.LogError(ex.ToString(), "Something went wrong");

                if (exceptionLogger != null)
                    exceptionLogger.WriteMessage(logData);
            }
            displayMessage.Message = "Logger file has been created successfully. Please check at on your drive location: D:/ErrorFile_1.txt";

            return displayMessage;
        }

        private void RaiseException()
        {
            throw new DivideByZeroException();
        }
    }
}
