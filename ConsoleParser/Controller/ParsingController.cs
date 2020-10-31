using ConsoleParser.Interfaces; 

namespace ConsoleParser.Controller
{
    // Класс для будущих нужд, сейчас пока не используется
    // TODO класс может заниматься сверкой списков книг из разных источников(парсеров)
    // Убирать дубли, формировать Dto и т.д.

    public class ParsingController
    {
        private IGetBooks _parser;
        private string _url;        
        private int _numberOfPages;
        private string _tagForSearch;
        private string _cssClassOfTag;
 
        public ParsingController( string urlAddressSite, int numbOfpages, string tag, string cssClass, IGetBooks parserExemplar )
        {
            this._parser = parserExemplar;
            this._url = urlAddressSite;
            this._numberOfPages = numbOfpages;
            this._tagForSearch = tag;
            this._cssClassOfTag = cssClass;
        }        
    }
}
