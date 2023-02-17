using ChatChimpClient.Core.Gui.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChatChimpClient.Core.Gui
{
    public class ViewPort
    {
        private BaseForm view;
        public ViewPort( BaseForm form ) {
            Application.EnableVisualStyles();
            this.view = form;
            if ( view.GetType() == typeof( LoginForm ) )
            {
                view = (LoginForm)view;
                view.startForm();
            }
        }

        

    }
}
