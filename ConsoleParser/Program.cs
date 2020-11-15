using System;
using ConsoleParser.Implemented_Parsers;
using ConsoleParser.Workers;

namespace ConsoleParser
{
    class Program
    {
       
        static void Main(string[] args)
        {
            using (var loader = new BrowserHtmlLoader())
            {
                OzonParser ozPars = new OzonParser(loader);

                var listBooks = ozPars.GetBooks();

                foreach (var book in listBooks)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            }

            Console.ReadLine();
        }
    }
}
