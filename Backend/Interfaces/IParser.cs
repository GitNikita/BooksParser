namespace Backend.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий общие настройки для реализующего парсера, для каждого свои
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// Обобщенный метод, необходим для получения данных из парсера
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        void GetData<T>(T data);
    }
}
