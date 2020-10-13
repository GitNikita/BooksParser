namespace Backend.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий общие настройки для реализующего парсера, для каждого свои
    /// </summary>
    interface ISettings
    {
        /// <summary>
        /// Адрес сайта
        /// </summary>
        string SiteUrl { get; }        
        /// <summary>
        /// Начальная страница для парсинга
        /// </summary>        
    }
}
