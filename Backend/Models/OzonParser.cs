using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Backend.Interfaces;
using IParser = Backend.Interfaces.IParse;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;

namespace Backend.Models
{
    class OzonParser : IParse
    {

        // private string _url = "https://habr.ru/ru";

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
