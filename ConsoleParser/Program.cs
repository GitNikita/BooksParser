using System;
using ConsoleParser.Controller;
using ConsoleParser.Models;
using ConsoleParser.Abstracts;

namespace ConsoleParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Tags from Ozon.ru:");
            Console.WriteLine(Environment.NewLine);
            
            OzonParser ozonParser = new OzonParser();
            // в идеале передавать с переменной вместо номера страницы ParsingController ozParser = new ParsingController($"https://www.ozon.ru/search/?deny_category_prediction=true&page={i}&text=sql", ozonParser);
            //ParsingController ozParser = new ParsingController($"https://www.ozon.ru/search/?deny_category_prediction=true&page=1&text=sql", ozonParser, 5);
            HabrParser habrParser = new HabrParser();
            ParsingController haParser = new ParsingController("https://habr.com/ru/", 4,"a","css", habrParser);
            // https://habr.com/ru/ + page3/


            //ParsingController haParser = new ParsingController("https://habr.com/ru/", habrParser);

            //var haResult = haParser.ReceiveDataFromHtml();


            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\nТеги с Хабра:");
            //Console.WriteLine(Environment.NewLine);

            //foreach (var tag in haResult)
            //{
            //    Console.WriteLine(tag);
            //}

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }
    }
}
