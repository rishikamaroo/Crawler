namespace Crawler
{
    using System;

    class Logger
    {

        public Logger()
        {

        }

        public void LogInfo(String error, params object[] args) {
            //Log into file
        }

        public void LogError(String error, params object[] args)
        {
            //Log the error
        }

        public void LogWarning(String error, params object[] args)
        {
            //Log the warning
        }

        public void LogException(string message, Exception e)
        {
            //Log the exception
        }
    }
}
