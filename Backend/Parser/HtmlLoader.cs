using System.Net;
using System.Net.Http;

using Backend.Models;

namespace Backend.Parser
{
    /// <summary>
    /// Класс по типу браузера загружает в объект код html страницы по url и pageId
    /// </summary>
    class HtmlLoader
    {
        /// <summary>
        /// Экземпляр 
        /// </summary>
        public HttpClient Client        { get; set; }
        public string Url               { get; private set; }
        public string ReturnedHtmlCode  { get; private set; }
        ///
        /// <summary>
        /// Конструктор загрузчика HTML
        /// </summary>
        /// <param name="settings">Настройки сайта для парсинга</param>
        public HtmlLoader(ConcreteSiteParser settings)
        {
            Client = new HttpClient();

            #region Без настройки TLS не удается подключиться к сайту
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            #endregion

            this.Client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            this.Url = $"{settings.SiteUrl}/{settings.PageId}/";
            this.Url = $"{settings.SiteUrl}";
        }

        /// <summary>
        /// Т.к данный метод асинхронный, и должен возвращать void, создано поле this.ReturnedHtmlCode
        /// </summary>
        /// <param name="pageId">Номер выкачиваемой страницы</param>
        public async void GetPageHtmlCode(int pageId)
        {
            string currentUrl = this.Url.Replace("{CurrentId}", pageId.ToString());
            // т.к. не найден синхронный метод, пришлось использовать асинхронную версию метода GetAsync()
            HttpResponseMessage responce = await this.Client.GetAsync(currentUrl);
            
            this.ReturnedHtmlCode = default;

            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                this.ReturnedHtmlCode = await responce.Content.ReadAsStringAsync();
            }            
        }
    }
}
