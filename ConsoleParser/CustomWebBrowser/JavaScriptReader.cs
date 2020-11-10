using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleParser.CustomWebBrowser
{
    static class JavaScriptReader
    {
        public static string outerHtml { get; private set; }

        public static void runBrowserThread(Uri url)
        {
            var th = new Thread(() => {
                var br = new WebBrowser();
                br.DocumentCompleted += browser_DocumentCompleted;
                br.Navigate(url);                
                Application.Run();                
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
            if (br.Url == e.Url)
            {
                Console.WriteLine("Navigated to {0}", e.Url);
                Application.ExitThread();   // Stops the thread
            }
        }


    }
}
