﻿using DovOnLogger;
using DovOnLogger.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SinkApp.Controllers
{
    public class ClientController : BaseController
    {
        private ILogger _logger;

        public ClientController(ILoggerProvider loggerProvider)
        {
            _logger = loggerProvider.CreateLogger(nameof(ClientController));
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return null;
        }

        [HttpGet]
        // GET: ClientController/Details
        public ActionResult Details()
        {
            ExceptionLogger exceptionLogger = null;
            LogData logData = new LogData();
            
            try
            {
                logData.Id = 1;
                logData.Type = "Concole";
                logData.LogLevel = "Debug";
                logData.Message = "This is debug message";

                exceptionLogger = new ExceptionLogger(new ConsoleLogger());

                _logger.LogDebug(logData.Message.ToString());
                exceptionLogger.WriteMessage(logData);

                // Raise faile exception
                RaiseException();
            }
            catch (Exception ex)
            {
                logData.LogLevel = "Error";
                logData.Message = ex.Message.ToString();

                _logger.LogError(ex.ToString(), "Something went wrong");

                if(exceptionLogger!=null)
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
