using ConsoleParser.Interfaces;

namespace ConsoleParser.Implemented_Parsers
{
    class HabrParser : IGetBooks
    {
        public string[] GetBooks()
        {
            throw new System.NotImplementedException();
        }

        private string AddPageNumber(string url, int pageNum)
        {
            string finalString = url + "page" + pageNum + "/";
            return finalString;
        }

        // TODO
        /*
         AddPageNumber_Test()
        string expected = "https://habr.com/ru/page3/";
        string actual = string.Empty;
         
        HabrParser haParser = new HabrParser();
        actual =  haParser.AddPageNumber("https://habr.com/ru/", 3);
        Assert.AreEquals(expected, actual);
        )
         */
    }
}
