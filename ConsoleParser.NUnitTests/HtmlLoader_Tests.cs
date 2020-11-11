using ConsoleParser.Workers;
using NUnit.Framework;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace ConsoleParser.NUnitTests
{
    [TestFixture]
    public class HtmlLoader_Tests
    {
        [Test]        
        public void ReadPage_ReturnCorrectDomObject_Test()
        {
            string inputTestUrl = "https://habr.com/ru/";
            
            HtmlLoader loader = new HtmlLoader(inputTestUrl);

            Assert.IsTrue(loader.ReadPage() is IHtmlDocument);            
        }
    }
}
