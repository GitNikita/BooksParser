using System;
using ConsoleParser.Workers;

namespace ConsoleParser
{
    class Program
    {
       
        static void Main(string[] args)
        {
            HtmlLoader loader = new HtmlLoader("https://habr.com/ru/");
            loader.ReadPage();


            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }
    }
}
