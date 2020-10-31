using NUnit.Framework;
using ConsoleParser.Workers;

namespace ConsoleParser.NUnitTests
{
    [TestFixture]
    public class HtmlLoader_Tests
    {
        [Test]        
        public void ReadPage_ReturnHtmlInString_Test()
        {
            string url = "https://habr.com/ru/";            
            HtmlLoader loader = new HtmlLoader(url);
            
            // Good - !String.Empty
            // Bad - String.Empty            
            
           // Если возвращается пусто, значит все хуюсто xD
           // При ошибках коннекта к сайту возвращается string.Empty
            Assert.IsNotEmpty(loader.ReadPage());
        }
    }
}
