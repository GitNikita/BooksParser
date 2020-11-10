using AngleSharp.Html.Dom;
using ConsoleParser.Implemented_Parsers;
using ConsoleParser.Workers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleParser.CustomWebBrowser
{
    // a helper class to start the message loop and execute an asynchronous task
    public class PageLoopDowloader
    {
        private string htmlAfterJsExecution;
        public void GetHtmlData()
        {
            try
            {
                //// download each page and dump the content
                //var task = DoWorkAsync("https://www.ozon.ru/category/yazyki-programmirovaniya-33705/?page=2");
                //task.Wait();
                //Console.WriteLine("DoWorkAsync completed.");
                //htmlAfterJsExecution = task.Result;
                
                
                
                DomStructureLoader angle = new DomStructureLoader(this.htmlAfterJsExecution);
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
                Console.WriteLine("Read Page is Failed: " + ex.Message);
            }

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();          
        }

        private string DoWork(string url)
        {
            Console.WriteLine("Start getting html source..");

            using (var wb = new WebBrowser())
            {
                wb.ScriptErrorsSuppressed = true;
                
                wb.Navigate(url);
                
                // the DOM is ready
                Console.WriteLine(url);
                var htmlRootElement = wb.Document.GetElementsByTagName("html")[0];
                var html = htmlRootElement.OuterHtml;
                while (true)
                {                    
                    if (wb.IsBusy) continue;
                    var htmlNow = htmlRootElement.OuterHtml;
                    if (html == htmlNow) break;

                    html = htmlNow;
                }
                return html;
            }

            Console.WriteLine("End reading html...");
            return null;
        }



        private static async Task<object> Run(Func<object[], Task<object>> worker, params object[] args)
        {
            var tcs = new TaskCompletionSource<object>();
            var thread = new Thread(() =>
            {
                EventHandler idleHandler = null;
                idleHandler = async (s, e) =>
                {
                    // handle Application.Idle just once
                    Application.Idle -= idleHandler;
                    // return to the message loop
                    await Task.Yield();
                    // and continue asynchronously
                    // propogate the result or exception
                    try
                    {
                        var result = await worker(args);
                        tcs.SetResult(result);
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                    // signal to exit the message loop
                    // Application.Run will exit at this point
                    Application.ExitThread();
                };
                // handle Application.Idle just once
                // to make sure we're inside the message loop
                // and SynchronizationContext has been correctly installed
                Application.Idle += idleHandler;
                Application.Run();
            });
            // set STA model for the new thread
            thread.SetApartmentState(ApartmentState.STA);
            // start the thread and await for the task
            thread.Start();
            try
            {
                return await tcs.Task;
            }
            finally
            {
                thread.Join();
            }
        }

        // navigate WebBrowser to the list of urls in a loop
        static async Task<string> DoWorkAsync(string url)
        {
            Console.WriteLine("Start getting html source..");

            using (var wb = new WebBrowser())
            {
                wb.ScriptErrorsSuppressed = true;

                TaskCompletionSource<bool> tcs = null;
                WebBrowserDocumentCompletedEventHandler documentCompletedHandler = (s, e) =>
                    tcs.TrySetResult(true);
                
                    tcs = new TaskCompletionSource<bool>();
                    wb.DocumentCompleted += documentCompletedHandler;
                    try
                    {
                        wb.Navigate(url);
                        // await for DocumentCompleted
                        await tcs.Task;
                    }
                    finally
                    {
                        wb.DocumentCompleted -= documentCompletedHandler;
                    }
                    // the DOM is ready
                    Console.WriteLine(url.ToString());
                    var htmlRootElement = wb.Document.GetElementsByTagName("html")[0];
                    var html = htmlRootElement.OuterHtml;
                    while (true)
                    {
                        await Task.Delay(500);
                        if (wb.IsBusy)  continue;
                        var htmlNow = htmlRootElement.OuterHtml;
                        if (html == htmlNow) break;
                        
                        html = htmlNow;
                    }
                    return html;                
            }

            Console.WriteLine("End reading html...");
            return null;
        }



    }
}