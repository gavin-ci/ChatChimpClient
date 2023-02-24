using CefSharp;
using CefSharp.WinForms;
using ChatChimpClient.Core.Gui.Browser.BrowserEvents;
using ChatChimpClient.Core.Gui.Forms;
using ChatChimpClient.Core.Readers.HTML;
using Newtonsoft.Json;

namespace ChatChimpClient.Core.Gui.Browser {
    public class Browser {
        BrowserWindow browserWnd { get; set; }

        ChromiumWebBrowser chrome { get; set; }

        public Browser() {
            browserWnd = new BrowserWindow();
            new Thread( browserWnd.startForm ).Start();
            while ( browserWnd.getBrowser() == null ) { Thread.Sleep(1); }
            chrome = browserWnd.getBrowser();
            chrome.JavascriptMessageReceived += javascriptMessage;
        }

        public void javascriptMessage(object? sender, JavascriptMessageReceivedEventArgs eventArgs) {
            string json = (string)eventArgs.Message;
            JsonStruct obj = new JsonStruct(json);
            JavascriptEventSwitch.HandleEvent(obj);
            //JavascriptEventSwitch.HandleEvent(msgId, msgData);
        }
        public void loadPage(string url)
            => chrome.LoadUrl(url);


        public void loadDoc(string htmlDoc)
            => chrome.LoadHtml(HtmlParser.getScript("CsharpFunctions") + htmlDoc);
    }

}
