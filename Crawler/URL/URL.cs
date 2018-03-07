﻿namespace Crawler
{
    using System;

    public class URL
    {
        public string url;

        private Logger logger;

        private ExceptionHandler exceptionHandler;

        public URL()
        {
            this.logger = new Logger();
        }

        public URL(String url) {
            this.url = url;
        }

        public URL(URL url, string newURL)
        {
            // Creates a URL by parsing the given spec within a specified context.
        }

        public URLConnection openConnection()
        {
            try
            {
                //try to create a new instance of URL connection here
                return new URLConnection();
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while initializing URL connection", e);
                return this.exceptionHandler.GenerateResponse<URLConnection>(e);
            }
        }

        public InputStream openStream()
        {
            try
            {
                //try to open the url stream here
                return new InputStream();
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while initializing URL connection", e);
                return this.exceptionHandler.GenerateResponse<InputStream>(e);
            }
        }

        public bool Valid()
        {
            try
            {
                //Validate 'this' url
                return true;
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while initializing URL connection", e);
                return false;
            }
        }

        public string getPath()
        {
            //return url path or empty string
            return string.Empty;
        }

        public URL FomatUrl(URL oldURL, string newUrl)
        {
            try
            {
                //return formatted URl from here
                return new URL();
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while formatting url", e);
                return this.exceptionHandler.GenerateResponse<URL>(e);
            }
        }
    }
}
