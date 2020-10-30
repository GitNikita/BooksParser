using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ConsoleParser.Abstracts;
using ConsoleParser.Workers;

namespace ConsoleParser.Controller
{
    class ParsingController
    {
        private Parser _parser;
        private string _url;
        private HtmlLoader _htmlLoader;
        private int _pageNumber;

        public ParsingController(string urlAddressSite, Parser parserExemplar, int pageNumber)
        {
            this._parser = parserExemplar;
            this._url = urlAddressSite;
            this._pageNumber = pageNumber;
        }                    

        public string[] ReceiveDataFromHtml()
        {            
            this._htmlLoader = new HtmlLoader();

            var htmlPage = _htmlLoader.ReadPage(this._url);

            // Применяется библиотека AngleSharp, интерфейс IHtmlDocument и класс HtmlParser,
            // подробнее на https://github.com/AngleSharp/AngleSharp 
            HtmlParser domParser = new HtmlParser();
            IHtmlDocument document =  domParser.ParseDocument(htmlPage);            

            return this._parser.GetData(document);
        }

        // Здесь необходимо реализовать выборку номера страницы &page из URL ссылки
        // и циклом пройти по всем страницам с книгами, должно вывести по 36 на лист 
        private string[] IncrementSitePages()
        {                
            //TODO Здесь необходимо выполнить получение кода страниц в цикле, 
            // проверить на некорректный код страницы, получаемый при отсутствии данных
            // наполнение основного массива с тегами по всем страницам

            for (int i = 1; i <= this._pageNumber; i++)
            { 
            
            }
            return "";
        }

    }
}
