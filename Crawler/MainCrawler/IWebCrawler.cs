namespace Crawler
{
    using System;
    using System.Collections.Generic;

    interface IWebcrawler
    {
        Content RetrieveContent(URL url);

        void Crawl(string[] args);

        void ProcessPage(IContent page);

        void AddNewURL(URL url, string newUrlString);

        void Init(String[] urls, out int maxPages);
    }
}
