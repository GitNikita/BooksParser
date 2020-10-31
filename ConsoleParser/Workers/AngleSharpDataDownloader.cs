using System;
using ConsoleParser.Interfaces;

using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace ConsoleParser.Workers
{
    public class AngleSharpDataDownloader
    {
        private string _sitePageInString;
        public AngleSharpDataDownloader(string sitePageInString)
        {
            this._sitePageInString = sitePageInString;
        }

        public IHtmlDocument GetDomStructureOfSite()
        {
            // Применяется библиотека AngleSharp
            // подробнее на https://github.com/AngleSharp/AngleSharp 
            HtmlParser domParser = new HtmlParser();
            IHtmlDocument document = domParser.ParseDocument(this._sitePageInString);
            return document;
        }
    }
}
