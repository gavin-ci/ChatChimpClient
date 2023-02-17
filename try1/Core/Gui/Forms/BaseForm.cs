using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatChimpClient.Core.Gui.Forms
{
    public class BaseForm : Form, 
        FormInterface
    {
        public void startForm()
        {
            InitializeComponent();
            Application.Run(this);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new Size(795, 460);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
