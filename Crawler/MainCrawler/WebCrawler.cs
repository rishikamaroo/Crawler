namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class WebCrawler : IWebcrawler
    {
        // Search limit for pages to search
        public static int SearchLimit = 20;

        // Max size of file 
        public static int MaxSize = 10000;

        // URLs to be searched
        private Queue<URL> SearchUrls;

        // Known URLs
        private ISet<URL> CachedUrls;

        private Logger Logger;

        private ExceptionHandler ExceptionHandler;

        private bool start = true;

        public WebCrawler()
        {
            this.Logger = new Logger();
            this.ExceptionHandler = new ExceptionHandler();
        }

        public Content RetrieveContent(URL url)
        {
            this.Logger.LogInfo("Retrieve content from the given url");
            URLConnection urlConnection = null;
            InputStream inputStream = null;
            try
            {
                this.Logger.LogInfo("Establish URL connection for ", url.getPath());
                urlConnection = url.openConnection();
                urlConnection.Connect();

                this.Logger.LogInfo("Get content from url");
                inputStream = url.openStream();
                return inputStream.GetContent();
            }
            finally
            {
                this.Logger.LogInfo("Close connections");
                inputStream?.CloseConnection();
                urlConnection?.CloseConnection();
            }
        }

        public void Crawl(string[] args)
        {
            this.Logger.LogInfo("Start Crawling...");
            try
            {
                /*
                  Managae Config settings from here in config.ini
                */

                Init(args, out int maxPagesToCrawl);
                if (start)
                {
                    this.Logger.LogError("Crawling stopped!");
                    return;
                }

                for (int i = 0; i < maxPagesToCrawl; i++)
                {
                    var url = SearchUrls.Dequeue();
                    var page = RetrieveContent(url);

                    if (page != null && page.Length() != 0)
                    {
                        ProcessPage(page);
                    }

                    if (SearchUrls.Count == 0)
                    {
                        break;
                    }
                }

                if (CachedUrls.Count != 0)
                {
                    FeedResultToDatabase(CachedUrls);
                }

                this.Logger.LogInfo("Search complete!");
            }
            catch (Exception e)
            {
                this.Logger.LogException("Exception while crawling", e);
            }
        }

        private void FeedResultToDatabase(ISet<URL> cachedUrls)
        {
            DB db = new DB();
            foreach (var cachedUrl in cachedUrls)
            {
                var sqlQuery = "Create a sql query command to enter in the record";
                db.runSql(sqlQuery);
            }
        }

        public void ProcessPage(IContent page)
        {
            try
            {
                this.Logger.LogInfo("Process the page to search for more urls");
                var pageText = page.GetText();
                var regex= new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");
                foreach (var match in regex.Matches(pageText))
                {
                    var newUrl = (string)match;
                    AddNewURL(page.url, newUrl);
                }
            }
            catch (Exception e)
            {
                this.Logger.LogException("Error while processing information", e);
            }
        }

        public void AddNewURL(URL oldURL, string newUrl)
        {
            this.Logger.LogInfo("Add the formatted url into the queue");
            var formattedURl = oldURL.FomatUrl(oldURL, newUrl);
            if (!CachedUrls.Contains(formattedURl))
            {
                CachedUrls.Add(formattedURl);
                SearchUrls.Enqueue(formattedURl);
                this.Logger.LogInfo("Found a new url: ", formattedURl.getPath());
            }
        }

        public void Init(string[] args, out int maxPagesToCrawl)
        {
            maxPagesToCrawl = SearchLimit;
            try
            {
                this.Logger.LogInfo("Initialize data structures to store known & new urls");
                var url = new URL(args[0]);
                if (!url.Valid())
                {
                    start = false;
                    this.Logger.LogWarning("Invalid URl");
                    return;
                }

                CachedUrls = new HashSet<URL>(); CachedUrls.Add(url);
                SearchUrls = new Queue<URL>(); SearchUrls.Enqueue(url);

                this.Logger.LogInfo("Starting search for Initial URL ", url.ToString());
                if (args.Length > 1)
                {
                    var userInputToCrawl = Int32.Parse(args[1]);
                    if (userInputToCrawl < maxPagesToCrawl) maxPagesToCrawl = userInputToCrawl;
                }

                this.Logger.LogInfo("Maximum number of pages:", maxPagesToCrawl);
            }
            catch (Exception e)
            {
                this.Logger.LogException("Exception while initializing data structures", e);
            }
        }
    }
}
