namespace Crawler
{
    using System;

    public class URL : IURL
    {
        public string url;

        private Logger logger;

        private ExceptionHandler ExceptionHandler;

        public URL()
        {
            this.logger = new Logger();
        }

        public URL(String url) {
            this.url = url;
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
                return this.ExceptionHandler.GenerateResponse<URLConnection>(e);
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
                return this.ExceptionHandler.GenerateResponse<InputStream>(e);
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
                // Creates a URL by parsing the given spec within a specified context.
                return new URL();
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while formatting url", e);
                return this.ExceptionHandler.GenerateResponse<URL>(e);
            }
        }
    }
}
