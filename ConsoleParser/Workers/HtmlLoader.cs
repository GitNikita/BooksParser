using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

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

        public string ReadPage()
        {

            try
            {
                ActivateTlsProtocol();

                HttpWebRequest requestToSite = (HttpWebRequest)WebRequest.Create(this._urlAddress);
                
                // Обязательно сбрасываем настройки прокси, иначе идет поиск прокси и запросы закрываются по таймауту
                requestToSite.Proxy = null;

                HttpWebResponse responseFromSite = (HttpWebResponse)requestToSite.GetResponse();

                return ResponseHandlingForOutput(responseFromSite);
                
            }
            
            catch (Exception exception)
            {
                GenerateErrorConsoleMessage(exception);

                return string.Empty;
            }

        }
        private void ActivateTlsProtocol()
        {
            // Без настройки TLS не удается подключиться к сайту
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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

        private void CloseAllReaders(HttpWebResponse httpResponseForClose, StreamReader streamForClose)
        {
            // Обязательно закрываем "html браузер"
            httpResponseForClose.Close();
            // Обязательно закрываем поток
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
