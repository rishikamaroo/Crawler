namespace Crawler
{
    using System;

    interface IWebcrawler
    {
        Content RetrieveContent(URL url);

        void Crawl(string[] args);

        void ProcessPage(Content page);

        void AddNewURL(URL url, string newUrlString);

        void Init(String[] urls, out int maxPages);
    }
}
