using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Backend.Parser
{
    /// <summary>
    /// Класс по типу браузера загружает в объект код html страницы
    /// </summary>
    class HtmlLoader
    {       
        private string ReturnedHtmlCode  { get; set; }

        public string ReadPage(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Method = "GET";
                request.KeepAlive = true;
                request.ContentType = "text/html; charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                this.ReturnedHtmlCode = string.Empty;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Sucess");
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
                return this.ReturnedHtmlCode;
            }
            catch (Exception)
            {

                throw;
            }
            
        }      
    }
}
