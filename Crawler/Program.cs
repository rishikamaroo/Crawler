using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public static void Main(String[] urls)
        {
            WebCrawler webCrawler = new WebCrawler();
            webCrawler.Crawl(urls);
        }
    }
}
