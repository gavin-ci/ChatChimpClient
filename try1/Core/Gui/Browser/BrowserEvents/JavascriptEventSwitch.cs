using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ChatChimpClient.Core.Gui.Browser.BrowserEvents {
    public static class JavascriptEventSwitch {

        public static async Task HandleEvent( int eventId, string eventData ) {
            switch(eventId) {
                case (int)JavascriptEventType.LOGIN:
                    string[] loginInfo = eventData.Split('|');
                    string username = loginInfo[0];
                    string password = loginInfo[1];
                    // login function
                return;
            }
        }
    }
}
