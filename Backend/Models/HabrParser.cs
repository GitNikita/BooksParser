using AngleSharp.Dom;
using AngleSharp.Html.Dom;

using System.Collections.Generic;
using System.Linq;

using Backend.Interfaces;

namespace Backend.Controllers
{
    class HabrParser : AbstractParser, IParser
    {
        public string   SiteUrl             { get; private set; } 
        public int      StartPageForParse   { get; private set; }
        public int      EndPageForParse     { get; private set; }
        public string   PageId              { get; private set; }

        public override string[] Parse(IHtmlDocument sitePage)
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
