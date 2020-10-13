using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Backend.Controllers
{
    /// <summary>
    /// Класс по типу браузера загружает в объект код html страницы
    /// </summary>
    class HtmlLoader
    {       
        public string ReturnedHtmlCode  { get; private set; }

        public void ReadPage(string urlAddress)
        {
            try
            {
                
                #region Без настройки TLS не удается подключиться к сайту
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                #endregion
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                // Обязательно сбрасываем настройки прокси, иначе идет поиск прокси и запросы закрываются по таймауту
                request.Proxy = null;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                this.ReturnedHtmlCode = string.Empty;

                if (response.StatusCode == HttpStatusCode.OK)
                {                    
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    this.ReturnedHtmlCode = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }                
            }
            catch (WebException webError)
            {
                Console.WriteLine
                    (
                    "При подключении к сайту возникла ошибка! " 
                    + Environment.NewLine 
                    + $"Проблемный сайт:  { urlAddress } "
                    + Environment.NewLine 
                    + webError.Message
                    );

                this.ReturnedHtmlCode = string.Empty;
            }
            
        }      
    }
}
