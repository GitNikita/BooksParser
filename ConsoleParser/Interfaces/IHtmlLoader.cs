using AngleSharp.Html.Dom;

namespace ConsoleParser.Interfaces
{
    internal interface IHtmlLoader
    {
        IHtmlDocument ReadPage(string urlAddress);
    }
}
