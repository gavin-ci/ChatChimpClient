using CefSharp;
using CefSharp.WinForms;
using ChatChimpClient.Core.Gui.Browser.BrowserEvents;
using ChatChimpClient.Core.Gui.Forms;
using ChatChimpClient.Core.Readers.HTML;

namespace ChatChimpClient.Core.Gui.Browser
{
    public class Browser
    {
        BrowserWindow browserWnd { get; set; }

        ChromiumWebBrowser chrome { get; set; }

        public Browser()
        {
            browserWnd = new BrowserWindow();
            new Thread( browserWnd.startForm ).Start();
            while( browserWnd.getBrowser() == null ) { Thread.Sleep(1); }
            chrome = browserWnd.getBrowser();
            chrome.JavascriptMessageReceived += javascriptMessage;
        }

        public void javascriptMessage( object? sender, JavascriptMessageReceivedEventArgs eventArgs ) {
            string msg = eventArgs.ConvertMessageTo<string>();
            int msgIdLen = msg.IndexOf('|');
            int msgId = int.Parse( msg.Substring( 0, msgIdLen ) );
            string msgData = msg.Substring( msgIdLen );
            Task.Run( Action() => () => JavascriptEventSwitch.HandleEvent(msgId, msgData) );
            }
        }

        public void loadPage( string url)
            => chrome.LoadUrl( url );
        

        public void loadDoc( string htmlDoc )
            => chrome.LoadHtml( HtmlParser.getScript("CsharpFunctions") + htmlDoc );
            
    }
}
