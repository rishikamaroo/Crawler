namespace Crawler
{
    using System;

    class ExceptionHandler
    {
        public T GenerateResponse<T>(Exception e)
        {
            //Generate Error responses with objects. A lot more logic needs to be added before driving the return back
            T t = default(T);
            return t;
        }
    }
}
