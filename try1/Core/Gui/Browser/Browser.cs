using CefSharp;
using CefSharp.WinForms;
using ChatChimpClient.Core.Gui.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void loadPage( string url)
            => chrome.LoadUrl( url );
        

        public void loadDoc( string htmlDoc )
            => chrome.LoadHtml( htmlDoc );
    }
}
