using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParser.Abstracts
{
    /// <summary>
    /// Абстракция, включающая переопределяемый метод с конкретной реализацией обработки страницы
    /// </summary>
    abstract class Parser
    {
        // Каждый потомок класса реализует добавление ссылки по-своему
        public virtual string AddPageNumber(string url, int pageNum) { return string.Empty; }

        public virtual string[] GetData(IHtmlDocument sitePage, string tag, string cssClass)
        {
            var result = sitePage.QuerySelectorAll(tag)
                .Where(x => x.ClassName?.Contains(cssClass) == true)
                .Select(x => x.TextContent)
                .ToArray();

            // Считываем все теги (tag) с классом (cssClass)
            return result;
        }                
    }
}
