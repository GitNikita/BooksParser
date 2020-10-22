using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ConsoleParser.Interfaces;
using ConsoleParser.Workers;

namespace ConsoleParser.Controller
{
    class ParsingController
    {
        private IParser _parser;
        private string _url;
        private HtmlLoader _htmlLoader;

        public ParsingController(string urlAddressSite, IParser parserExemplair)
        {
            this._parser = parserExemplair;
            this._url = urlAddressSite;
        }
        
        // Здесь необходимо реализовать выборку номера страницы &page из URL ссылки
        // и циклом пройти по всем страницам с книгами, должно вывести по 36 на лист
             

        public string[] ReceiveDataFromHtml()
        {
            // Выделяем память под объект
            this._htmlLoader = new HtmlLoader();

            var htmlPage = _htmlLoader.ReadPage(this._url);

            // Применяется библиотека AngleSharp, интерфейс IHtmlDocument и класс HtmlParser,
            // подробнее на https://github.com/AngleSharp/AngleSharp 
            HtmlParser domParser = new HtmlParser();
            IHtmlDocument document =  domParser.ParseDocument(htmlPage);

            PageSeeker seeker = new PageSeeker();            

            return this._parser.GetData(document);
        }        
    }
}
