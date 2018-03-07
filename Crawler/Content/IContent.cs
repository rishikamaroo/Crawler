namespace Crawler
{
    interface IContent
    {
        URL url { get; }

        string GetText();

        int Length();
    }
}
