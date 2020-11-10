using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
using ConsoleParser.Implemented_Parsers;
using AngleSharp.Html.Dom;
using ConsoleParser.Workers;

namespace WinFormWebBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {           
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        async private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var cts = new CancellationTokenSource(10000); // cancel in 10s
                var html = await LoadDynamicPage("https://www.ozon.ru/category/yazyki-programmirovaniya-33705/", cts.Token);                
                
                AngleSharpDataDownloader angle = new AngleSharpDataDownloader(html);
                IHtmlDocument document = angle.GetDomStructureOfSite();
                OzonParser ozPars = new OzonParser();
                var listBooks = ozPars.GetBooks(document, "a", "a2g0 tile-hover-target");
                foreach (var book in listBooks)
                {
                    Console.WriteLine(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // navigate and download 
        async Task<string> LoadDynamicPage(string url, CancellationToken token)
        {
            // navigate and await DocumentCompleted
            var tcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                tcs.TrySetResult(true);

            using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
            {
                this.webBrowser1.DocumentCompleted += handler;
                try
                {
                    this.webBrowser1.Navigate(url);
                    await tcs.Task; // wait for DocumentCompleted
                }
                finally
                {
                    this.webBrowser1.DocumentCompleted -= handler;
                }
            }

            // get the root element
            var documentElement = this.webBrowser1.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(500, token);

                // continue polling if the WebBrowser is still busy
                if (this.webBrowser1.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }

            // consider the page fully rendered 
            token.ThrowIfCancellationRequested();
            return html;
        }

    }
}
