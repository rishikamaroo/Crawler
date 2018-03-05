namespace Crawler
{
    using System;

    class ExceptionHandler
    {
        public T GenerateResponse<T>(Exception e)
        {
            //Generate Error responses
            T t = default(T);
            return t;
        }
    }
}
