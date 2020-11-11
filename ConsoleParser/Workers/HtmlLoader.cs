using System;
using System.IO;
using System.Net;
using System.Text;
using AngleSharp.Html.Dom;

namespace ConsoleParser.Workers
{
    /// <summary>
    /// Класс подключается по Url адресу, затем возвращает код html страницы в виде строки
    /// </summary>
    public class HtmlLoader
    {
        private string _urlAddress;
        private string _textOfHtmlPage;

        public HtmlLoader ( string urlAddress )
        {
            this._urlAddress = urlAddress;
        }

        public IHtmlDocument ReadPage()
        {
            try
            {
                ActivateTls_Ssl_Protocols();

                HttpWebRequest requestToSite = (HttpWebRequest)WebRequest.Create(this._urlAddress);

                // Обязательно сбрасываем настройки прокси, иначе запросы закрываются по таймауту,
                // если создатель запроса отделен прокси сервером

                requestToSite.Proxy = null;                
                requestToSite.UseDefaultCredentials = true;

                HttpWebResponse responseFromSite = (HttpWebResponse)requestToSite.GetResponse();
                var sitePageInString = ResponseHandlingForOutput(responseFromSite);
                
                return GetHtmlDomStructure(sitePageInString);
            }
            
            catch (Exception exception)
            {
                GenerateErrorConsoleMessage(exception);
                return GetHtmlDomStructure(string.Empty);
            }

        }        

        private void ActivateTls_Ssl_Protocols()
        {
            // Без настройки TLS/SSL не удается подключиться к части сайтов
            ServicePointManager.SecurityProtocol = 
                SecurityProtocolType.Ssl3 
                | SecurityProtocolType.Tls 
                | SecurityProtocolType.Tls11 
                | SecurityProtocolType.Tls12;
            
            ServicePointManager.Expect100Continue = true;            
        }

        private string ResponseHandlingForOutput(HttpWebResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = StreamReader.Null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                this._textOfHtmlPage = readStream.ReadToEnd();

                CloseAllReaders(response, readStream);

                return this._textOfHtmlPage;
            }
            else
            {
                return this._textOfHtmlPage = string.Empty;
            }
        }
        private IHtmlDocument GetHtmlDomStructure(string htmlPage)
        {
            DomStructureLoader angleDownloader = new DomStructureLoader(htmlPage);
            return angleDownloader.GetDomStructureOfSite();
        }

        private void CloseAllReaders(HttpWebResponse httpResponseForClose, StreamReader streamForClose)
        {
            // Обязательно закрываем "html браузер"
            httpResponseForClose.Close();
            // Обязательно закрываем поток чтения
            streamForClose.Close();
        }
        private void GenerateErrorConsoleMessage(Exception ex)
        {
            Console.WriteLine
                    (
                    "При работе HtmlLoader.ReadPage(urlAddress) возникла ошибка: "
                    + Environment.NewLine
                    + ex.Message
                    );
        }
        
    }
}
