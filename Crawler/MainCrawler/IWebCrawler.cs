using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    interface IWebcrawler
    {
        Content RetrieveContent(URL url);

        void Crawl(string[] args);

        void ProcessPage(URL url, Content page);

        void AddNewURL(URL url, string newUrlString);

        void Init(String[] urls, out int maxPages);
    }
}
