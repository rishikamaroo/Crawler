namespace Crawler
{
    interface IURL
    {
        URLConnection openConnection();

        InputStream openStream();

        URL FomatUrl(URL oldURL, string newUrl);
    }
}
