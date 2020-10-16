using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ConsoleParser.Interfaces;
using ConsoleParser.Workers;


namespace ConsoleParser.Controller
{
    class ParsingController
    {
        private IParse _parser;
        private string _url;
        private HtmlLoader _htmlLoader;

        public ParsingController(string urlAddressSite, IParse parserExemplair)
        {
            this._parser = parserExemplair;
            this._url = urlAddressSite;
        }
        
        public string[] ReceiveDataFromHtml()
        {
            // Выделяем память под объект
            this._htmlLoader = new HtmlLoader();

            var htmlPage = _htmlLoader.ReadPage(this._url);

            // Применяется библиотека AngleSharp, интерфейс IHtmlDocument и класс HtmlParser,
            //        // подробнее на https://github.com/AngleSharp/AngleSharp 
            HtmlParser domParser = new HtmlParser();
            IHtmlDocument document =  domParser.ParseDocument(htmlPage);         
            
            return this._parser.GetData(document);
        }        
    }
}
