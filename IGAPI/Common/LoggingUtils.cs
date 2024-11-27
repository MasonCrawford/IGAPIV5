using System.Net;
using Microsoft.Extensions.Logging;

namespace Common;

public static class LoggingUtils
{
    public static void LogWarningIfHttpStatusCodeNotOk(string message, HttpStatusCode httpStatusCode, ILogger logger)
    {
        if (httpStatusCode != HttpStatusCode.OK)
            logger.LogWarning(message);
        else
            logger.LogInformation(message);
    }
}