using System.Linq;
using AngleSharp.Html.Dom;
using ConsoleParser.Interfaces;

namespace ConsoleParser.Models
{
    class OzonParser : IGetBooks
    {
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
            throw new System.NotImplementedException();
        }

        private string AddPageNumber(string url, int pageNum)
        {
            return "";
        }
    }
}


