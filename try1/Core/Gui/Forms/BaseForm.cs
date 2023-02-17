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
    public class BaseForm : Form, 
        FormInterface
    {
        public ChromiumWebBrowser browser { get; set; }
        public void startForm()
        {
            InitializeComponent();
            initBrowser("www.google.com");
            Application.Run(this);
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new Size(795, 460);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
        public void initBrowser( string filePath )
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser( filePath );
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.Size = new Size(200,200);
        }
    }
}
