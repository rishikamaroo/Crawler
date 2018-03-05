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

        private Logger logger;

        private ExceptionHandler exceptionHandler;

        private bool start = true;

        public WebCrawler()
        {
            this.logger = new Logger();
            this.exceptionHandler = new ExceptionHandler();
        }

        public Content RetrieveContent(URL url)
        {
            this.logger.LogInfo("Retrieve content from the given url");
            URLConnection urlConnection = new URLConnection();
            InputStream inputStream = new InputStream();
            try
            {
                this.logger.LogInfo("Establish URL connection for ", url.getPath());
                urlConnection = url.openConnection();
                urlConnection.Connect();

                this.logger.LogInfo("Get content from url");
                inputStream = url.openStream();
                return inputStream.GetContent();
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception when trying to retrieve content from web page ", e);
                return this.exceptionHandler.GenerateResponse<Content>(e);
            }
            finally
            {
                this.logger.LogInfo("Close connections");
                inputStream?.CloseConnection();
                urlConnection?.CloseConnection();
            }
        }

        public void Crawl(string[] args)
        {
            this.logger.LogInfo("Start Crawling...");
            try
            {
                /*
                  Managae Config settings from here in config.ini
                 */

                Init(args, out int maxPagesToCrawl);
                if (start)
                {
                    for (int i = 0; i < maxPagesToCrawl; i++)
                    {
                        var url = SearchUrls.Dequeue();
                        var page = RetrieveContent(url);

                        if (page != null && page.Length() != 0)
                        {
                            ProcessPage(page);
                        }

                        if (CachedUrls.Count == 0)
                        {
                            break;
                        }
                    }

                    if (CachedUrls.Count != 0)
                    {
                        FeedResultToDatabase(CachedUrls);
                    }
                    this.logger.LogInfo("Search complete!");
                }
                else
                {
                    this.logger.LogError("Crawling stopped!");
                }
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while crawling", e);
            }
        }

        private void FeedResultToDatabase(ISet<URL> cachedUrls)
        {
            try
            {
                DB db = new DB();
                foreach (var cachedUrl in cachedUrls)
                {
                    var sqlQuery = "Create a sql query command to enter in the record";
                    db.runSql(sqlQuery);
                }
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while logging query into database", e);
            }
        }

        public void ProcessPage(Content page)
        {
            try
            {
                this.logger.LogInfo("Process the page to search for more urls");
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
                this.logger.LogException("Error while processing information", e);
            }
        }

        public void AddNewURL(URL oldURL, string newUrl)
        {
            try
            {
                this.logger.LogInfo("Add the formatted url into the queue");
                var formattedURl = URL.FomatUrl(oldURL, newUrl);
                if (!CachedUrls.Contains(formattedURl))
                {
                    CachedUrls.Add(formattedURl);
                    SearchUrls.Enqueue(formattedURl);
                    this.logger.LogInfo("Found a new url: ", formattedURl.getPath());
                }
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while adding a new url", e);
                return;
            }
        }

        public void Init(string[] args, out int maxPagesToCrawl)
        {
            maxPagesToCrawl = SearchLimit;
            try
            {
                this.logger.LogInfo("Initialize data structures to store known & new urls");
                var url = new URL(args[0]);
                if (url.Valid())
                {
                    CachedUrls = new HashSet<URL>(); CachedUrls.Add(url);
                    SearchUrls = new Queue<URL>(); SearchUrls.Enqueue(url);

                    this.logger.LogInfo("Starting search for Initial URL ", url.ToString());
                    if (args.Length > 1)
                    {
                        var userInputToCrawl = Int32.Parse(args[1]);
                        if (userInputToCrawl < maxPagesToCrawl) maxPagesToCrawl = userInputToCrawl;
                    }
                    logger.LogInfo("Maximum number of pages:", maxPagesToCrawl);
                }
                else
                {
                    start = false;
                    this.logger.LogWarning("Invalid URl");
                }
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while initializing data structures", e);
            }
        }
    }
}
