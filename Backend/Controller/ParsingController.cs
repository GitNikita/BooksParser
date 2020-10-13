using System;
using Backend;
using IParser = Backend.Interfaces.IParser;

namespace Backend.Controller
{
    class ParsingController
    {
        private IParser _parser;
        private string _url;
        private Backend.Workers.HtmlLoader _htmlLoader;

        public ParsingController(string urlAddressSite, IParser parserExemplair)
        {
            this._parser = parserExemplair;
            this._url = urlAddressSite;
        }

        public void ReceiveDataFromHtml()
        {
            this._htmlLoader = new HtmlLoader();
            var text = _htmlLoader.ReadPage(this._url);
            _parser.GetObject(text);
        }

    }
}
