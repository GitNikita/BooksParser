using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using ConsoleParser.Interfaces;
using IParser = ConsoleParser.Interfaces.IParser;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;

namespace ConsoleParser.Models
{
    class OzonParser : IParser
    {
        public string[] GetData(IHtmlDocument sitePage)
        {
            List<string> list = new List<string>();

            #region Считываем все заголовки <a href с классами "a2g0"
            IEnumerable<IElement> items = sitePage.QuerySelectorAll("a")
                .Where(item =>
                item.ClassName != null
                &&
                item.ClassName.Contains("a2g0"));
            #endregion

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            return list.ToArray();
        }
    }
}
