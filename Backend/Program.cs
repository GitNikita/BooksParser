using Backend.Controller;
using Backend.Models;
using System;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            //OzonParser ozonParser = new OzonParser();
            //ParsingController parser = new ParsingController("https://www.ozon.ru/category/yazyki-programmirovaniya-33705", ozonParser);

            HabrParser habrParser = new HabrParser();
            ParsingController parser = new ParsingController("https://habr.com/ru/", habrParser);
            
            var result = parser.ReceiveDataFromHtml();
            
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }
    }
}
