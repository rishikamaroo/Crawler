namespace Crawler
{
    using System;

    class ExceptionHandler
    {
        public T GenerateResponse<T>(Exception e)
        {
            //Generate Error responses with objects
            T t = default(T);
            return t;
        }
    }
}
