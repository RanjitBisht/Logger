using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SinkApp.Controllers.Api
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
            try
            {
                _logger.LogDebug("Getting started");
                _logger.LogWarning("This is a warning message!");
                _logger.LogInformation("Welcome to the user!!");
                
                // Check for log level
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    // code here to perform as per debug loglevel
                }
                // Raise faile exception
                RaiseException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "Something went wrong");
            }
            
            return null;
        }

        private void RaiseException()
        {
            throw new DivideByZeroException();
        }

    }
}
