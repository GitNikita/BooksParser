using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Backend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            //HabrParser habrParser = new HabrParser();
            OzonParser ozonParser = new OzonParser();            

            // Применяется библиотека AngleShap, интерфейс IHtmlDocument и класс HtmlParser,
            //        // подробнее на https://github.com/AngleSharp/AngleSharp
            HtmlParser domParser = new HtmlParser();
            IHtmlDocument document = domParser.ParseDocument(pageFromHabr);
            var result = Parse(document);

            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
            Console.ReadLine();
        }
    }
}
