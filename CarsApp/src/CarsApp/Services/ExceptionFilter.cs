using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApp.Services
{
    /// <summary>
    /// Catch all exceptions and log them.
    /// </summary>
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CustomExceptionFilter(/*ILoggerFactory loggerFactory*/)
        {
            _logger = new LoggerFactory().CreateLogger("CustomExceptionFilter");
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.ToString());
            base.OnException(context);
        }
    }
}
