using System.Collections.Generic;
using System.Linq;

using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace Backend.Parser
{
    class ConcreteSiteParser
    {
        /// <summary>
        /// Адрес сайта
        /// </summary>
        public string SiteUrl { get; set; }
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public string PageId { get; set; }
        /// <summary>
        /// Начальная страница для парсинга
        /// </summary>
        public int StartPageForParse { get; set; }
        /// <summary>
        /// Конечная страница для парсинга
        /// </summary>
        public int EndPageForParse { get; set; }

        /// <summary>
        /// Содержит один метод, который выполняет поиск конкретного
        /// </summary>
        /// <param name="sitePage">Универсальная интерфейсная ссылка на полный контент HTML страницы, чтобы парсить через один метод сразу заголовки, теги и содержимое</param>
        public string[] Parse(IHtmlDocument sitePage)
        {   
            // Запускаем парсинг заголовков сайта Хабр
            // Список для хранения заголовков
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
                //Добавляем заголовки в коллекцию.
                list.Add(item.TextContent);
            }
            return list.ToArray();
        }
    }
}
