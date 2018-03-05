namespace Crawler
{
    using System;

    public class InputStream
    {
        public InputStream()
        {

        }

        public void CloseConnection()
        {
            try
            {
                //try to get close the connection
            }
            catch (Exception)
            {
                
            }
        }

        public Content GetContent()
        {
            try
            {
                //try to get content of inputstream
                return new Content();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}