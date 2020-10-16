using AngleSharp.Dom;
using AngleSharp.Html.Dom;

using System.Collections.Generic;
using System.Linq;
using IParser = ConsoleParser.Interfaces.IParse;

using ConsoleParser.Interfaces;

namespace ConsoleParser.Models
{
    class HabrParser : IParse
    {
        //private string _url = "https://www.ozon.ru/category/yazyki-programmirovaniya-33705/";

        public string[] GetData(IHtmlDocument sitePage)
        {
            List<string> list = new List<string>();

            #region Считываем все заголовки <a href с классами "post__title_link"
            IEnumerable<IElement> items = sitePage.QuerySelectorAll("a")
                .Where(item =>
                item.ClassName != null
                &&
                item.ClassName.Contains("post__title_link"));
            #endregion

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            return list.ToArray();
        }       
    }
}
