
namespace ConsoleParser.Workers
{
    class PageSeeker
    {
        // Класс будет заниматься прохождением в цикле по страницам сайта с выборкой данных
        private int _pageNumber = 5;
        public PageSeeker()
        {
            Seek();
        }
        private void Seek()
        {
            for (int i = 1; i <= _pageNumber; i++)
            {
                System.Console.WriteLine($"Это {i} страница");                
            }
        }
    }
}
