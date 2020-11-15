using AngleSharp.Html.Dom;
using ConsoleParser.Interfaces;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleParser.Workers
{
    internal class BrowserHtmlLoader : IHtmlLoader, IDisposable
    {
        private FirefoxDriver _browser;
        public BrowserHtmlLoader()
        {
            var firefoxOptions = new FirefoxOptions();
            // включаем silent режим браузера
            firefoxOptions.AddArguments("--headless");
            _browser = new FirefoxDriver(firefoxOptions);
        }
        public void Dispose()
        {
            _browser.Dispose();
        }

        public IHtmlDocument ReadPage(string urlAddress)
        {
            TimeSpan ts = new TimeSpan(3);

            _browser.Navigate().GoToUrl(urlAddress);

            // обязательно добавляем ожидание 
            WebDriverWait wait = new WebDriverWait(_browser, ts);
            var result = _browser.PageSource;

            DomStructureLoader angleDownloader = new DomStructureLoader(result);

            return angleDownloader.GetDomStructureOfSite();
        }
    }
}
