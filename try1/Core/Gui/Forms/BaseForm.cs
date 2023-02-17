using System;
using System.Collections.Generic;
using System.Linq;
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
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser(filePath);
            this.Controls.Add(browser);
            browser.Dock= DockStyle.Fill;
        }
    }
}
