using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleParser.Controller;
using ConsoleParser.Models;


namespace ConsoleParser
{
    class Program
    {
        static void Main(string[] args)
        {
            OzonParser ozonParser = new OzonParser();
            ParsingController ozParser = new ParsingController("https://www.ozon.ru/search/?deny_category_prediction=true&page=1&text=sql", ozonParser);
            
            var ozResult = ozParser.ReceiveDataFromHtml();

            //HabrParser habrParser = new HabrParser();
            //ParsingController haParser = new ParsingController("https://habr.com/ru/", habrParser);

            //var haResult = haParser.ReceiveDataFromHtml();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nТеги с Озона:");
            Console.WriteLine(Environment.NewLine);

            foreach (var item in ozResult)
            {
                Console.WriteLine(item);
            }

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
