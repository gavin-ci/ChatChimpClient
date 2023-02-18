using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace ChatChimpClient.Core.Gui.Forms
{
    public class BrowserWindow : Form
    {
        private ChromiumWebBrowser browser { get; set; }
        [STAThread]
        public void startForm()
        {
            InitializeComponent();
            initBrowser();
            Application.Run(this);
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new Size(795, 460);
            this.Name = "ChatChimp";
            this.ResumeLayout(false);

        }
        public void initBrowser()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser();
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        public ChromiumWebBrowser getBrowser() 
            => browser;
    }
}
