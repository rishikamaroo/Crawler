namespace Crawler
{
    using System;

    class Program
    {
        public static void Main(String[] urls)
        {
            WebCrawler webCrawler = new WebCrawler();
            webCrawler.Crawl(urls);
        }
    }
}
