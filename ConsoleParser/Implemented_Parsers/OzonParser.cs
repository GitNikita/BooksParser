using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;
using ConsoleParser.Interfaces;

namespace ConsoleParser.Implemented_Parsers
{
    class OzonParser : IGetBooks
    {
        private IHtmlLoader _htmlLoader;

        public OzonParser(IHtmlLoader htmlLoader)//HtmlLoader
        {
            _htmlLoader = htmlLoader;
        }
        public string[] GetBooks(IHtmlDocument sitePage, string tag, string cssClass)
        {
            var result = sitePage.QuerySelectorAll(tag)
                .Where(x => x.ClassName?.Contains(cssClass) == true)
                .Select(x => x.TextContent)
                .ToArray();

            // Считываем все теги (tag) с классом (cssClass)
            return result;
        }

        public string[] GetBooks()
        {
            var url = "https://www.ozon.ru/category/kompyuternye-tehnologii-40020/?page=";
            var pageNumber = 1;
            var tag ="a";
            var cssClass = "a2g0 tile-hover-target";
            var empty = false;

            var infoPage = new List<string>();

            do
            {
                var sitePage = _htmlLoader.ReadPage($"{url}{pageNumber}");

                var result = sitePage.QuerySelectorAll(tag)
                .Where(x => x.ClassName?.Contains(cssClass) == true)
                .Select(x => x.TextContent)
                .ToArray();

                if (result.Any())
                    infoPage.AddRange(result);
                else
                    empty = true; 

                pageNumber++;
            } while (!empty);

            return infoPage.ToArray();
        }

        private string AddPageNumber(string url, int pageNum)
        {
            return "";
        }
    }
}


