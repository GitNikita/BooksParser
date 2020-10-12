using Backend.Models;
using Backend.Parser;
using System;
using System.Net;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConcreteSiteParser settings = new ConcreteSiteParser();
            //settings.SiteUrl = "https://habr.com/ru";
            //settings.PageId = "";
            //settings.StartPageForParse = 1;
            //settings.EndPageForParse = 2;

            //HtmlLoader loader = new HtmlLoader();
            //loader.ReadPage("https://habr.com");

            //ParsingWorker parser = new ParsingWorker(settings);
            //parser.Start();

            //using (WebClient client = new WebClient())
            //{
            //    client.Credentials = CredentialCache.DefaultCredentials;
            //    string htmlCode = client.DownloadString("https://habr.com/ru");
            //    Console.WriteLine(htmlCode);
            //}

            string urlAddress = "https://habr.com/ru";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.ReadLine();
        }
    }
}
