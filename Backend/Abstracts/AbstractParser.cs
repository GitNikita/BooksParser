using System;
using System.Collections.Generic;
using System.Linq;

using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Backend.Controllers;

namespace Backend.Interfaces
{
    abstract class AbstractParser
    {
        public string FinalHtmlCodeForParser { get; private set; }

        public AbstractParser(string urlAddress)
        {
            GetHtmlPageThrougthAngleSharpLibrary(urlAddress);            
        }

        private void GetHtmlPageThrougthAngleSharpLibrary(string url)
        {
            HtmlLoader htmlLoader = new HtmlLoader();
            htmlLoader.ReadPage(url);
            
            SaveHtmlForReceiveToParser(htmlLoader);
        }

        /// <summary>
        /// Сохраняем страницу html в поле для доступа к нему через конкретный парсер
        /// </summary>
        private void SaveHtmlForReceiveToParser(HtmlLoader loader)
        {
            this.FinalHtmlCodeForParser = loader.ReturnedHtmlCode;
        }

        /// <summary>
        /// Содержит один метод, который выполняет поиск конкретной информации по тегу 
        /// </summary>
        /// <param name="sitePage">Универсальная интерфейсная ссылка на полный контент HTML страницы, чтобы парсить через один метод сразу заголовки, теги и содержимое</param>
        public virtual string[] Parse(IHtmlDocument sitePage)
        {         
            List<string> list = new List<string>();            
            return list.ToArray();
        }
    }
}
