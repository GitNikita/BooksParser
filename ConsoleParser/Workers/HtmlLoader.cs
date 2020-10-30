using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleParser.Workers
{
    /// <summary>
    /// Класс по типу браузера загружает в объект код html страницы
    /// </summary>
    class HtmlLoader
    {
        public string ReadPage(string urlAddress)
        {           
            try
            {
                // Без настройки TLS не удается подключиться к сайту
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                // Обязательно сбрасываем настройки прокси, иначе идет поиск прокси и запросы закрываются по таймауту
                request.Proxy = null;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                
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

                    string endResult = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();

                    return endResult;
                }
                else
                {
                    return string.Empty;
                }
            }
            
            catch (Exception ex)
            {                
                Console.WriteLine
                    (
                    "При работе HtmlLoader.ReadPage(urlAddress) возникла ошибка: "
                    + Environment.NewLine                     
                    + ex.Message
                    );

                return string.Empty;
            }            
        }       
    }
}
