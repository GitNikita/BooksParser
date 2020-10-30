using ConsoleParser.Abstracts;

namespace ConsoleParser.Models
{
    class HabrParser : Parser
    {
        public override string AddPageNumber(string url, int pageNum)
        {
            string finalString = url + "page" + pageNum + "/";
            return finalString;
        }

        // 
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
