using System;
using ConsoleParser.Implemented_Parsers;
using ConsoleParser.Workers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ConsoleParser
{
    class Program
    {

        public static void Main(string[] args)
        {
            var firefoxOptions = new FirefoxOptions();
            // включаем silent режим браузера
            firefoxOptions.AddArguments("--headless");
            
            using (var browser = new FirefoxDriver(firefoxOptions))
            {
                TimeSpan ts = new TimeSpan(10);
                
                browser.Navigate().GoToUrl("https://www.ozon.ru/category/yazyki-programmirovaniya-33705/?page=2");
                
                // обязательно добавляем ожидание 
                WebDriverWait wait = new WebDriverWait(browser, ts);
                var result = browser.PageSource;

                DomStructureLoader angleDownloader = new DomStructureLoader(result);
               
                OzonParser ozPars = new OzonParser();
                var listBooks = ozPars.GetBooks(angleDownloader.GetDomStructureOfSite(), "a", "a2g0 tile-hover-target");

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
