using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;

namespace ChatChimpClient.Core.Gui.Forms
{
    public class LoginForm : BaseForm
    {
        public new void startForm()
        {

            // Order matters!
            InitializeComponent();
            initBrowser("www.google.com");
            Application.Run(this);
        }
    }
}
