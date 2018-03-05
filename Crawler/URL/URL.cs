using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class URL
    {
        public string url;

        private Logger logger;

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
            // The new URL is created from the given context URL and the spec argument
        }

        public URLConnection openConnection()
        {
            try
            {
                //try to create a new instance of URL connection  here
                return new URLConnection();
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while initializing URL connection", e);
                return null;
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
                return null;
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

        public static URL FomatUrl(URL oldURL, string newUrl)
        {
            try
            {
                //return formatted URl from here
                return new URL();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
