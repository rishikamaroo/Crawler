namespace Crawler
{
    using System;

    public class InputStream
    {
        private ExceptionHandler ExceptionHandler;

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
                return;
            }
        }

        public Content GetContent()
        {
            try
            {
                //try to get content of inputstream
                return new Content();
            }
            catch (Exception e)
            {
                return this.ExceptionHandler.GenerateResponse<Content>(e);
            }
        }
    }
}