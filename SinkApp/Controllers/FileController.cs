using DovOnLogger;
using DovOnLogger.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Details()
        {
            ExceptionLogger exceptionLogger = null;
            LogData logData = new LogData();

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

            return null;
        }

        private void RaiseException()
        {
            throw new DivideByZeroException();
        }
    }
}
