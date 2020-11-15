namespace ConsoleParser.Dto
{
    internal class BaseBookDto
    {       
        public string Name { get; set; }

        public string Price { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public DetailBookDto Detail { get; set; }
    }
}
