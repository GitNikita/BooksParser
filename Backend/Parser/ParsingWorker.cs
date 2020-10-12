using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

using Backend.Models;
using System;

namespace Backend.Parser
{
    class ParsingWorker
    {
        HtmlLoader Loader;              // Загрузчик кода страницы
        ConcreteSiteParser Parser;      // Экземпляр парсера конкретного сайта
        public string[] result;

        public ParsingWorker(ConcreteSiteParser HabrParser)
        {
            this.Parser = HabrParser;
            this.Loader = new HtmlLoader(this.Parser);
        }

        public void Start()
        {            
            GetInfoFromHtml();
        }       

        private async void GetInfoFromHtml()
        {             
            for (int i = Parser.StartPageForParse; i <= Parser.EndPageForParse; i++)
            {
                Loader.GetPageHtmlCode(i); // Получаем код страницы
                // Применяется библиотека AngleShap, интерфейс IHtmlDocument и класс HtmlParser,
                // подробнее на https://github.com/AngleSharp/AngleSharp
                HtmlParser domParser = new HtmlParser();
                IHtmlDocument document = await domParser.ParseDocumentAsync(Loader.ReturnedHtmlCode);
                this.result = Parser.Parse(document);
                
                foreach (var tag in this.result)
                {
                    Console.WriteLine(tag);
                }
            }            
        }
    }
}
