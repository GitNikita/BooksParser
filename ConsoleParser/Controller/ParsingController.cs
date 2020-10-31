using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ConsoleParser.Abstracts;
using ConsoleParser.Workers;
using System.Linq;

namespace ConsoleParser.Controller
{
    class ParsingController
    {
        private Parser _parser;
        private string _url;
        private HtmlLoader _htmlLoader;
        private int _numberOfPages;
        private string _tagForSearch;
        private string _cssClassOfTag;
 
        public ParsingController(string urlAddressSite, int numbOfpages, string tag, string cssClass, Parser parserExemplar)
        {
            this._parser = parserExemplar;
            this._url = urlAddressSite;
            this._numberOfPages = numbOfpages;
            this._tagForSearch = tag;
            this._cssClassOfTag = cssClass;
        }                    

        public string[] ReceiveDataFromHtml()
        {            
            this._htmlLoader = new HtmlLoader(this._url);

            var htmlPage = _htmlLoader.ReadPage();

            // Применяется библиотека AngleSharp, интерфейс IHtmlDocument и класс HtmlParser,
            // подробнее на https://github.com/AngleSharp/AngleSharp 
            HtmlParser domParser = new HtmlParser();
            IHtmlDocument document =  domParser.ParseDocument(htmlPage);            

            return this._parser.GetData(document, this._tagForSearch, this._cssClassOfTag);
        }

        // Здесь необходимо реализовать выборку номера страницы &page из URL ссылки
        // и циклом пройти по всем страницам с книгами, должно вывести по 36 на лист 
        private string[] IncrementSitePages()
        {                
            //TODO Здесь необходимо выполнить получение кода страниц в цикле, 
            // проверить на некорректный код страницы, получаемый при отсутствии данных
            // наполнение основного массива с тегами по всем страницам

            for (int i = 1; i <= this._numberOfPages; i++)
            { 
            
            }
            string[] arrString = new string[] { "One", "Two", "Three" };

            return arrString;
        }

    }
}
