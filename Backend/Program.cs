using Backend.Models;
using Backend.Parser;
using System;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSiteParser settings = new ConcreteSiteParser();
            settings.SiteUrl = "https://habr.com/ru";
            settings.PageId = "";
            settings.StartPageForParse = 1;
            settings.EndPageForParse = 2;

            ParsingWorker parser = new ParsingWorker(settings);
            parser.Start();

            


            Console.ReadLine();
        }
    }
}
