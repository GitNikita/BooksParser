using AngleSharp.Html.Dom;

namespace ConsoleParser.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий общие настройки для реализующего парсера, для каждого свои
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// Метод необходим для получения данных из парсера
        /// </summary>
        /// <param name="sitePage">Документ HTML полученный из загрузчика</param>
        /// <returns></returns>
        string[] GetData (IHtmlDocument sitePage);
    }
}
