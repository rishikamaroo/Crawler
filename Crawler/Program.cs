namespace Crawler
{
    using System;

    class Program
    {
        public static void Main(String[] args)
        {
            WebCrawler webCrawler = new WebCrawler();
            webCrawler.Crawl(args);
        }
    }
}
