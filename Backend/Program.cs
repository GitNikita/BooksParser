using Backend.Controller;
using Backend.Models;
using System;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {            
            OzonParser ozonParser = new OzonParser();
            ParsingController ozParser = new ParsingController("https://www.ozon.ru/category/yazyki-programmirovaniya-33705", ozonParser);
            
            var ozResult = ozParser.ReceiveDataFromHtml();

            HabrParser habrParser = new HabrParser();
            ParsingController haParser = new ParsingController("https://habr.com/ru/", habrParser);
            
            var haResult = haParser.ReceiveDataFromHtml();

            Console.WriteLine("\nТеги с Озона:");
            Console.WriteLine(Environment.NewLine);

            foreach (var item in ozResult)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nТеги с Хабра:");
            Console.WriteLine(Environment.NewLine);

            foreach (var tag in haResult)
            {
                Console.WriteLine(tag);
            }
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }
    }
}
