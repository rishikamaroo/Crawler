﻿namespace Crawler
{
    using System;

    public class Content : IContent
    {
        public URL url { get; }

        public Content()
        {

        }

        public string GetText()
        {
            //Get the text of the page
            return String.Empty;
        }

        public int Length()
        {
            //calculate & return the size of the content
            return 0;
        }
    }
}
